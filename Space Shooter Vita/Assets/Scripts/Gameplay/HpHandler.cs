using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpHandler : MonoBehaviour 
{
	GameObject pShip;
	DamageHandler pDMG;
	ActiveObjectStats pActive;

	void Awake()
	{
		pShip = GameObject.FindGameObjectWithTag("Player");
		pDMG = pShip.GetComponent<DamageHandler>();
		pActive = pShip.GetComponent<ActiveObjectStats>();
	}

	void Update()
	{
		if (pShip)
		{
			this.GetComponent<Image>().fillAmount = pDMG.hp / pActive.objectMaxHp;
		}
		//Debug.Log(this.GetComponent<Image>().fillAmount + "/" + pShip.GetComponent<DamageHandler>().hp);
	}
}
