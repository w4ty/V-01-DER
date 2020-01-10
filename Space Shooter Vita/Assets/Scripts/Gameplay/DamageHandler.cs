using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DamageHandler : MonoBehaviour

{
	public float hp;
	int dmgCalc;
	public float invLength = 0;
	int objectLayer;
	float invFrames = 0;
	public string objectGrouping;
	private Animator anim;
	private SpriteRenderer spriteControl;
	public GameObject damageText;
	private ActiveObjectStats currentObjectStats;
	private ActiveObjectStats otherObjectStats;
	private GameObject playerShip;
	private MoveForward movementController;
	private FacePlayer rotController;
	private BattleSystem battleSystem;
	private bool disableControllers;
	static public string[] objToSeek;
	static public int objAmount;

	void Start()
	{
		battleSystem = GameObject.Find("BattleHandler").GetComponent<BattleSystem>();
		playerShip = GameObject.Find("Player_Ship_a");
		currentObjectStats = this.GetComponent<ActiveObjectStats>();
		if (this.GetComponent<MoveForward>() == true)
		{
			movementController = this.GetComponent<MoveForward>();
			rotController = this.GetComponent<FacePlayer>();
			disableControllers = true;
		}
		if (transform.childCount > 0)
		{
			spriteControl = this.transform.GetChild(0).GetComponent<SpriteRenderer>();
		}
		hp = currentObjectStats.objectMaxHp;
		objectLayer = gameObject.layer;
		anim = GetComponent<Animator>();
	}
	void OnTriggerEnter2D(Collider2D other)
	{

		otherObjectStats = other.GetComponent<ActiveObjectStats>();
		//Debug.Log("Triggered");

		//Math for damage calculations
		dmgCalc = Mathf.RoundToInt
			(
				(
					(
					otherObjectStats.objectDamage
					+ Random.Range
						(
						otherObjectStats.objectLowerRandomDamage, otherObjectStats.objectHigherRandomDamage
						)
					)
					/ currentObjectStats.objectArmour
				)
			);
		hp -= dmgCalc;

		//Adding damage text next to the damaged unit
		Vector3 ghostPos = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
		Quaternion ghostRot = new Quaternion();
		damageText.GetComponentInChildren<Text>().text = dmgCalc.ToString();
		Instantiate(damageText, ghostPos, ghostRot, GameObject.Find("WorldSpaceCanvas").transform);

		//Mess regarding invincibility frames
		invFrames = invLength;
		gameObject.layer = 10;
	}
	void Update()
	{
		invFrames -= Time.deltaTime;
		if (invFrames <= 0)
		{
			gameObject.layer = objectLayer;
		}
		if (hp <= 0)
		{
			try
			{
				this.gameObject.layer = 10;
				if (disableControllers == true)
				{
					Destroy(movementController);
					Destroy(rotController);
				}
				anim.SetBool("playDestroy", true);
				HideSprite();
			}
			catch { }
		}
	}

	public void kill()
	{
		for (int i = 0; i < objAmount; i++)
		{
			if (objectGrouping == objToSeek[i])
			{
				battleSystem.ObjectiveAdd(objToSeek[i], i);
			}
		}
		if (objectGrouping != "Player")
		{
			playerShip.GetComponent<PlayerStatistics>().currentXP += currentObjectStats.objectXpGiven;
		}
		CleanUp();
	}

	void HideSprite()
	{
		spriteControl.sprite = null;
	}

	public void CleanUp()
	{
		Destroy(gameObject);
	}
}
