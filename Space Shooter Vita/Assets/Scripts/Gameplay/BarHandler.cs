using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarHandler : MonoBehaviour
{
	public GameObject xpBar;
	public GameObject pShip;

	/*void Awake()
	{
		GameObject pShip = GameObject.Find("Player_Ship_a");
		GameObject xpBar = GameObject.Find("XpBar");
	}*/

	void Update ()
	{
		xpBar.GetComponent<Image>().fillAmount = pShip.GetComponent<PlayerStatistics>().currentXP / pShip.GetComponent<PlayerStatistics>().nextXP;
		Debug.Log(xpBar.GetComponent<Image>().fillAmount);
	}
}
