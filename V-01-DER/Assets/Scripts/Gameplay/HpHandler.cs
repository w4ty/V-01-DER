using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpHandler : MonoBehaviour 
{
	GameObject pShip;
	DamageHandler pDMG;
	ActiveObjectStats pActive;
	GameObject textObj;
	Text text;

	void Awake()
	{
		textObj = GameObject.Find("HpText");
		pShip = GameObject.FindGameObjectWithTag("Player");
		pDMG = pShip.GetComponent<DamageHandler>();
		pActive = pShip.GetComponent<ActiveObjectStats>();
		text = textObj.GetComponent<Text>();
		text.text = string.Format("HP {0}", pActive.objectMaxHp);
	}

	public void OnDamaged()
	{
		if (pShip)
		{
			this.GetComponent<Image>().fillAmount = pDMG.hp / pActive.objectMaxHp;
			text.text = string.Format("HP {0}", pDMG.hp);
		}
		//Debug.Log(this.GetComponent<Image>().fillAmount + "/" + pShip.GetComponent<DamageHandler>().hp);
	}
}
