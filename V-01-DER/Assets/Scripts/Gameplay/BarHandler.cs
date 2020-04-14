using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarHandler : MonoBehaviour
{
	GameObject pShip;
	PlayerStatistics pStats;
	GameObject textObj;
	Text text;
	Text level;

	void Awake()
	{
		level = GameObject.Find("LvlText").GetComponent<Text>();
		textObj = GameObject.Find("XpText");
		pShip = GameObject.FindGameObjectWithTag("Player");
		pStats = pShip.GetComponent<PlayerStatistics>();
		text = textObj.GetComponent<Text>();
		text.text = string.Format("{0}/{1}", pStats.currentXP, pStats.nextXP);
	}

	void Update ()
	{
		if (pShip)
		{
			this.GetComponent<Image>().fillAmount = pStats.currentXP / pStats.nextXP;
			text.text = string.Format("exp {0}/{1}", pStats.currentXP, pStats.nextXP);
			level.text = string.Format("level {0}", pStats.shipLVL);
		}
		//Debug.Log(this.GetComponent<Image>().fillAmount + "/" + pShip.GetComponent<PlayerStatistics>().currentXP / pShip.GetComponent<PlayerStatistics>().nextXP);
	}
}
