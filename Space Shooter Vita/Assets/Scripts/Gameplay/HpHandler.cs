using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpHandler : MonoBehaviour 
{
	GameObject pShip;

	void Awake()
	{
		pShip = GameObject.FindGameObjectWithTag("Player");
	}

	void Update()
	{
		this.GetComponent<Image>().fillAmount = pShip.GetComponent<DamageHandler>().hp / pShip.GetComponent<ActiveObjectStats>().objectMaxHp;
		//Debug.Log(this.GetComponent<Image>().fillAmount + "/" + pShip.GetComponent<DamageHandler>().hp);
	}
}
