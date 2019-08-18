using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DamageHandler : MonoBehaviour

{
	public float hp;
	public float invLength = 0;
	int objectLayer;
	float invFrames = 0;
	private Animator anim;
	private SpriteRenderer spriteControl;
	public GameObject damageText;

	void Start()
	{
		if (transform.childCount > 0)
		{
			spriteControl = this.transform.GetChild(0).GetComponent<SpriteRenderer>();
		}
		hp = this.GetComponent<ActiveObjectStats>().objectMaxHp;
		objectLayer = gameObject.layer;
		anim = GetComponent<Animator>();
	}
	void OnTriggerEnter2D(Collider2D other)
	{

		Debug.Log("Triggered");

		//Math for damage calculations
		int dmgCalc = Mathf.RoundToInt(
			(other.GetComponent<ActiveObjectStats>().objectDamage / this.GetComponent<ActiveObjectStats>().objectArmour)
			+ Random.Range(other.GetComponent<ActiveObjectStats>().objectLowerRandomDamage, other.GetComponent<ActiveObjectStats>().objectHigherRandomDamage) * 10);
		hp -= dmgCalc;

		//Adding damage text next to the damaged unit
		Vector3 ghostPos = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
		Quaternion ghostRot = new Quaternion();
		Instantiate(damageText, ghostPos, ghostRot, GameObject.Find("WorldSpaceCanvas").transform);
		damageText.GetComponent<Text>().text = dmgCalc.ToString() + "!";


		//Mess regarding invincibility frames
		invFrames = invLength;
		gameObject.layer = 10;
	}
	void Update()
	{
		invFrames -= Time.deltaTime;
		if(invFrames <= 0)
		{
			gameObject.layer = objectLayer;
		}
		if (hp <= 0)
		{
			try
			{
				anim.SetBool("playDestroy", true);
				HideSprite();
			}
			catch { }
		}
	}
	void kill()
	{
		Destroy(gameObject);
	}
	void HideSprite()
	{
		spriteControl.sprite = null;
	}
}
