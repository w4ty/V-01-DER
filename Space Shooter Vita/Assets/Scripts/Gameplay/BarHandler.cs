using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarHandler : MonoBehaviour
{
	GameObject pShip;

	void Awake()
	{
		pShip = GameObject.FindGameObjectWithTag("Player");
	}

	void Update ()
	{
		this.GetComponent<Image>().fillAmount = pShip.GetComponent<PlayerStatistics>().currentXP / pShip.GetComponent<PlayerStatistics>().nextXP;
		//Debug.Log(this.GetComponent<Image>().fillAmount + "/" + pShip.GetComponent<PlayerStatistics>().currentXP / pShip.GetComponent<PlayerStatistics>().nextXP);
	}
}
