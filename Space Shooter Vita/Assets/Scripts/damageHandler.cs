using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageHandler : MonoBehaviour
{
	public int maxHP = 2;
	public int hp;
	float invFrames = 0;
	void Start()
	{
		hp = maxHP;
	}
	void OnTriggerEnter2D()
	{
		Debug.Log("Triggered");
		if(invFrames <= 0)
		{
			hp -= maxHP / 2;
			invFrames = 2f;
		}
	}
	void Update()
	{
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
