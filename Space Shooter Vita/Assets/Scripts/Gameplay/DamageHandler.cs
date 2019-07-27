using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DamageHandler : MonoBehaviour

{
	public int maxHP;
	public int damageAmount;
	public float armorAmount;
	public float hp;
	public float invLength = 0;
	int objectLayer;
	float invFrames = 0;
	private Animator anim;
	private SpriteRenderer spriteControl;

	void Start()
	{
		if (transform.childCount > 0)
		{
			spriteControl = this.transform.GetChild(0).GetComponent<SpriteRenderer>();
		}
		hp = maxHP;
		objectLayer = gameObject.layer;
		anim = GetComponent<Animator>();
	}
	void OnTriggerEnter2D()
	{
		Debug.Log("Triggered");

		hp -= ActiveObjectStats.damageOnCol/armorAmount;
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
