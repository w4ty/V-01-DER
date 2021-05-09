using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DamageHandler : MonoBehaviour

{
	static public string[] ObjToSeek;
	static public int ObjAmount;
	public float Hp;
	public string ObjectGrouping;
	public GameObject DamageText;
	private int dmgCalc;
	private HpHandler hpHandler;
	private GhostHpBar ghostBar;
	private Animator anim;
	private SpriteRenderer spriteControl;
	private ActiveObjectStats currentObjectStats;
	private ActiveObjectStats otherObjectStats;
	private GameObject playerShip;
	private MoveForward movementController;
	private FacePlayer rotController;
	private BattleSystem battleSystem;
	private bool disableControllers;
	private ParticleSystem destroyParticle;
	private EnemyHpBar enemyHpBar;

	void Start()
	{
		destroyParticle = transform.Find("DestructionParticles").gameObject.GetComponent<ParticleSystem>();
		ghostBar = GameObject.FindGameObjectWithTag("GhostBar").GetComponent<GhostHpBar>();
		hpHandler = GameObject.FindGameObjectWithTag("Hp").GetComponent<HpHandler>();
		battleSystem = GameObject.Find("BattleHandler").GetComponent<BattleSystem>();
		enemyHpBar = GameObject.FindGameObjectWithTag("EnemyBar").GetComponent<EnemyHpBar>();
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
		Hp = currentObjectStats.ObjectMaxHp;
		anim = GetComponent<Animator>();
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag != "Obstacle")
		{
			if (gameObject.layer == 10 || other.gameObject.layer == 10)
			{
				Vector3 ghostPos = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
				Quaternion ghostRot = new Quaternion();

				Debug.Log("DODGED");
				DamageText.GetComponentInChildren<Text>().text = "Miss";
				DamageText.GetComponentInChildren<Text>().fontSize = 26;
				DamageText.GetComponentInChildren<Text>().color = new Color(1, 0.9f, 0);
				playerShip.GetComponent<DashHandler>().EndCooldown();

				Instantiate(DamageText, ghostPos, ghostRot, GameObject.Find("WorldSpaceCanvas").transform);
			}
			else
			{
				otherObjectStats = other.GetComponent<BulletDataHolder>().actStats;
				Debug.Log(string.Format("Triggered collision for damage handling model between {0} _this_ and {1} _other_.", name, other.name));

				//Adding damage text next to the damaged unit
				Vector3 ghostPos = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
				Quaternion ghostRot = new Quaternion();

				//Math for damage calculations
				//dmgCalc = Mathf.RoundToInt(otherObjectStats.objectDamage / currentObjectStats.objectArmour);

				if (otherObjectStats.ObjectCritChance >= Random.Range(1, 100) && otherObjectStats.ObjectCritChance < 101)
				{
					dmgCalc = Mathf.RoundToInt((otherObjectStats.ObjectDamage * otherObjectStats.ObjectCritDamage) / currentObjectStats.ObjectArmour);
					DamageText.GetComponentInChildren<Text>().text = string.Format("{0}!", dmgCalc.ToString());
					DamageText.GetComponentInChildren<Text>().fontSize = 30;
					DamageText.GetComponentInChildren<Text>().color = new Color(1, 0.1f, 0.1f);
				}
				else if(otherObjectStats.ObjectCritChance >= Random.Range(101, 200))
				{
					dmgCalc = Mathf.RoundToInt(otherObjectStats.ObjectDamage * otherObjectStats.ObjectCritDamage);
					DamageText.GetComponentInChildren<Text>().text = string.Format("{0}!!", dmgCalc.ToString());
					DamageText.GetComponentInChildren<Text>().fontSize = 32;
					DamageText.GetComponentInChildren<Text>().color = new Color(1, 0.1f, 0.7f);
				}
				else
				{
					dmgCalc = Mathf.RoundToInt(otherObjectStats.ObjectDamage / currentObjectStats.ObjectArmour);
					DamageText.GetComponentInChildren<Text>().text = string.Format("{0}", dmgCalc.ToString());
					DamageText.GetComponentInChildren<Text>().fontSize = 26;
					DamageText.GetComponentInChildren<Text>().color = new Color(1, 1, 1);
				}
				Hp -= dmgCalc;



				Instantiate(DamageText, ghostPos, ghostRot, GameObject.Find("WorldSpaceCanvas").transform);

				//Handle hp bar animation for player damage
				if (gameObject == playerShip)
				{
					hpHandler.OnDamaged();
					ghostBar.LowerBar();
				}
				else
				{
					enemyHpBar.UpdateHealth(Hp, currentObjectStats.ObjectMaxHp, currentObjectStats.ObjectName, currentObjectStats.ObjectLevel);
				}
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
		if (Hp <= 0 && gameObject.layer != 10)
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
		for (int i = 0; i < ObjAmount; i++)
		{
			if (ObjectGrouping == ObjToSeek[i])
			{
				battleSystem.ObjectiveAdd(ObjToSeek[i], i);
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
