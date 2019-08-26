using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatistics : MonoBehaviour
{

	public GameObject xpText;
	public int perkSelected;
	public int shipLVL;
	public int currentXP;
	public float nextXP;

	void LevelUp()
	{
		currentXP = 0;
		nextXP = Mathf.RoundToInt((Mathf.Pow(1.06f, shipLVL)) * 100);
	}
	void Update()
	{
		nextXP = Mathf.RoundToInt((Mathf.Pow(1.06f, shipLVL)) * 100);
	}
}
