using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatistics : MonoBehaviour {

	public GameObject xpText;
	public int perkSelected;
	public int shipLVL;
	public int currentXP;
	public float nextXP;

	void LevelUp()
	{
		currentXP = 0;
		nextXP = shipLVL * shipLVL * 64;
	}
	void Update()
	{
		nextXP = shipLVL*shipLVL*64;
	}
}
