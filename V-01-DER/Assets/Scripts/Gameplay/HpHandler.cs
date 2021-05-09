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

	void Start()
	{
		textObj = GameObject.Find("HpText");
		pShip = GameObject.FindGameObjectWithTag("Player");
		pDMG = pShip.GetComponent<DamageHandler>();
		pActive = pShip.GetComponent<ActiveObjectStats>();
		text = textObj.GetComponent<Text>();
		text.text = string.Format("STATUS: {0}%", pActive.ObjectMaxHp);
	}

	public void OnDamaged()
	{
		if (pShip)
		{
			this.GetComponent<Image>().fillAmount = pDMG.Hp / pActive.ObjectMaxHp;
			text.text = string.Format("STATUS: {0}%", pDMG.Hp);
		}
		//Debug.Log(this.GetComponent<Image>().fillAmount + "/" + pShip.GetComponent<DamageHandler>().hp);
	}
}
