using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleHandler : MonoBehaviour
{
	static public bool isInBattle;
	static public int battleId = 1;
	static public int battleDifficulty = 1;
	static public string battleType="Generic";
	static public int portal1_amount;
	public GameObject portal1Pref;


	public void PrepareBattle()
	{
		INIParser ini = new INIParser();
		ini.Open(SetTarget.worldDataPath + "Battles/" + battleType + "/Difficulty" + battleDifficulty + "/" + battleType + battleId + ".ini");
		Debug.LogWarning(ini.FileName);
		portal1_amount = ini.ReadValue("InitialProperties", "AmountOf_Portal1", 1);
		Debug.Log("port1 amount " + portal1_amount);
		for(int i = 1; i <= portal1_amount; i++)
		{
			Debug.LogError(i);
			Instantiate(portal1Pref).transform.position = new Vector3(ini.ReadValue("Portal1_"+i, "Position_X", 0), ini.ReadValue("Portal1_" + i, "Position_Y", 0), 0);
		}
	}
}
