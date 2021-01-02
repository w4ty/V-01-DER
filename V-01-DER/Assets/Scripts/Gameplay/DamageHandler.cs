using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DamageHandler : MonoBehaviour

{
	HpHandler hpHandler;
	public float hp;
	int dmgCalc;
	public float invLength = 0;
	//int objectLayer;
	//float invFrames = 0;
	public string objectGrouping;
	GhostHpBar ghostBar;
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
	private ParticleSystem destroyParticle;
	static public string[] objToSeek;
	static public int objAmount;

	void Start()
	{
		destroyParticle = transform.Find("DestructionParticles").gameObject.GetComponent<ParticleSystem>();
		ghostBar = GameObject.FindGameObjectWithTag("GhostBar").GetComponent<GhostHpBar>();
		hpHandler = GameObject.FindGameObjectWithTag("Hp").GetComponent<HpHandler>();
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
	//	objectLayer = gameObject.layer;
		anim = GetComponent<Animator>();
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag != "Obstacle")
		{
			otherObjectStats = other.GetComponent<BulletDataHolder>().actStats;
			//Debug.Log("Triggered");

			//Adding damage text next to the damaged unit
			Vector3 ghostPos = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
			Quaternion ghostRot = new Quaternion();

			//Math for damage calculations
			dmgCalc = Mathf.RoundToInt
				(
						otherObjectStats.objectDamage
						/ currentObjectStats.objectArmour
				);
			if (otherObjectStats.objectCritChance > Random.Range(0, 100))
			{
				dmgCalc *= Mathf.RoundToInt(otherObjectStats.objectCritDamage);
				damageText.GetComponentInChildren<Text>().text = string.Format("{0}!", dmgCalc.ToString());
				damageText.GetComponentInChildren<Text>().fontSize = 30;
				damageText.GetComponentInChildren<Text>().color = new Color(1, 0.1f, 0.1f);
				Debug.LogError("CRIT " + damageText.GetComponentInChildren<Text>().color);
			}
			else
			{
				damageText.GetComponentInChildren<Text>().text = string.Format("{0}", dmgCalc.ToString());
				damageText.GetComponentInChildren<Text>().fontSize = 26;
				damageText.GetComponentInChildren<Text>().color = new Color(1, 1, 1);
			}
			hp -= dmgCalc;

			
			
			Instantiate(damageText, ghostPos, ghostRot, GameObject.Find("WorldSpaceCanvas").transform);

			//Mess regarding invincibility frames
			/*invFrames = invLength;
			gameObject.layer = 10;*/

			//Handle hp bar animation for player damage
			if (this.gameObject == playerShip)
			{
				hpHandler.OnDamaged();
				ghostBar.LowerBar();
			}
		}
	}
	void Update()
	{
		/*invFrames -= Time.deltaTime;
		if (invFrames <= 0)
		{
			gameObject.layer = objectLayer;
		}*/
		if (hp <= 0 && gameObject.layer != 10)
		{
			try
			{
				destroyParticle.Play();
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
