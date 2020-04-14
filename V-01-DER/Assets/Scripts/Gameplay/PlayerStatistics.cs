using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatistics : MonoBehaviour
{
	public GameObject levelAnimHandle;
	public GameObject xpText;
	public int perkSelected;
	public int shipLVL;
	public int currentXP;
	public float nextXP;
	public int skillPoints;
	public int skillInTree;

	void LevelUp()
	{
		if (shipLVL > 0)
		{
			levelAnimHandle.GetComponent<LevelUpAnim>().CallAnims();
		}
		shipLVL += 1;
		nextXP = Mathf.RoundToInt((Mathf.Pow(1.09f, shipLVL)) * 100 + shipLVL);
		skillPoints += 4;
	}
	void Update()
	{
		if (currentXP >= nextXP)
		{
			currentXP -= Mathf.RoundToInt(nextXP);
			LevelUp();
		}
	}
}
