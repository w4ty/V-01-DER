using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleHandler : MonoBehaviour
{
	static public bool isInBattle;
	static public int battleId = 3;
	static public int battleDifficulty = 1;
	static public string battleType = "Generic";
	static public int portal1_amount;
	static public int explmine_amount;
	static public int turret1_amount;
	public GameObject playerShip;
	public GameObject portal1Pref;
	public GameObject explminePref;
	public BattleSystem battleSystem;
	public GameObject enemyGroup;
	public GameObject locationHud;

	public GameObject[] spawnables;
	//static public List<int> amounts;

	void Start()
	{
		locationHud = GameObject.Find("LocGroup");
	}

	public void PrepareBattle()
	{
		KillSwitch.kill = false;
		INIParser ini = new INIParser();
		ini.Open(SetTarget.worldDataPath + "Battles/" + battleType + "/Difficulty" + battleDifficulty + "/" + battleType + battleId + ".ini");
		battleSystem.GetObjectives(ini.FileName);
		//Debug.LogWarning(ini.FileName);

		GameObject.Find("Player_Ship_a").transform.position = new Vector3(ini.ReadValue("InitialProperties", "PlayerPosX", 1), ini.ReadValue("InitialProperties", "PlayerPosY", 1), 0);

		PlayerMovementAlt.maxYCoordinate = ini.ReadValue("InitialProperties", "Border_Ymax", 1);
		PlayerMovementAlt.maxXCoordinate = ini.ReadValue("InitialProperties", "Border_Xmax", 1);
		PlayerMovementAlt.minYCoordinate = ini.ReadValue("InitialProperties", "Border_Ymin", -1);
		PlayerMovementAlt.minXCoordinate = ini.ReadValue("InitialProperties", "Border_Xmin", -1);

		//Array.Resize(ref amounts, ini.ReadValue("InitialProperties", "ObjectsToSpawn", 1) + 1);

		for (int a = 1; a <= ini.ReadValue("InitialProperties", "ObjectsToSpawn", 1); a++)
		{
			Debug.Log(ini.ReadValue("Object" + a, "id", 1));
			Instantiate(spawnables[ini.ReadValue("Object" + a, "id", 1)], new Vector3(ini.ReadValue("Object" + a, "PosX", 0), ini.ReadValue("Object" + a, "PosY", 0)), new Quaternion(), enemyGroup.transform);
		//	amounts[ini.ReadValue("Object" + a, "id", 1)] += 1;
		}
		/*portal1_amount = ini.ReadValue("InitialProperties", "AmountOf_Portal1", 1);
		Debug.Log("port1 amount " + portal1_amount);
		for (int i = 1; i <= portal1_amount; i++)
		{
			//	Debug.LogError("created Portal1_" + i);
			Instantiate(portal1Pref, new Vector3(ini.ReadValue("Portal1_" + i, "Position_X", 0), ini.ReadValue("Portal1_" + i, "Position_Y", 0)), new Quaternion(), enemyGroup.transform);
		}
		explmine_amount = ini.ReadValue("InitialProperties", "AmountOf_ExplMine", 1);
		Debug.Log("explmine amount " + explmine_amount);
		for (int i = 1; i <= explmine_amount; i++)
		{
			//	Debug.LogError("created ExplMine_" + i);
			Instantiate(explminePref, new Vector3(ini.ReadValue("ExplMine_" + i, "Position_X", 0), ini.ReadValue("ExplMine_" + i, "Position_Y", 0)), new Quaternion(), enemyGroup.transform);
		}
		turret1_amount = ini.ReadValue("InitialProperties", "AmountOF_Turret1", 1);
		Debug.Log("turret1 amount " + turret1_amount);
		for (int i = 1; i <= turret1_amount; i++)
		{
		}*/
		PrepareHud(false);
	}

	public void PrepareHud(bool setTo)
	{
		locationHud.SetActive(setTo);
	}

	public void EndBattle()
	{
		PrepareHud(true);
	}
}
