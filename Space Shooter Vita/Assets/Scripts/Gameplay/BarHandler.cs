using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarHandler : MonoBehaviour
{
	GameObject pShip;
	PlayerStatistics pStats;

	void Awake()
	{
		pShip = GameObject.FindGameObjectWithTag("Player");
		pStats = pShip.GetComponent<PlayerStatistics>();
	}

	void Update ()
	{
		if (pShip)
		{
			this.GetComponent<Image>().fillAmount = pStats.currentXP / pStats.nextXP;
		}
		//Debug.Log(this.GetComponent<Image>().fillAmount + "/" + pShip.GetComponent<PlayerStatistics>().currentXP / pShip.GetComponent<PlayerStatistics>().nextXP);
	}
}
