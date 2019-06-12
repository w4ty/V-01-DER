using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageHandler : MonoBehaviour
{
	public int maxHP = 20;
	public int hp;
	public float invLength = 0;
	int objectLayer;
	float invFrames = 0;
	void Start()
	{
		hp = maxHP;
		objectLayer = gameObject.layer;
	}
	void OnTriggerEnter2D()
	{
		Debug.Log("Triggered");

			hp -= 10;
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
			kill();
		}
	}
	void kill()
	{
		Destroy(gameObject);
	}

}
