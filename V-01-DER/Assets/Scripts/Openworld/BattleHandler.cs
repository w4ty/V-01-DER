using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleHandler : MonoBehaviour
{
	static public bool isInBattle;
	public GameObject playerShip;
	public GameObject portal1Pref;
	public GameObject explminePref;
	public BattleSystem battleSystem;
	public GameObject enemyGroup;
	public GameObject locationHud;
	public float lastPosX;
	public float lastPosY;

	public GameObject[] spawnables;

	void Start()
	{
		playerShip = GameObject.Find("Player_Ship_a");
		locationHud = GameObject.Find("LocGroup");
	}

	public void SaveLastPos()
	{
		lastPosX = playerShip.transform.position.x;
		lastPosY = playerShip.transform.position.y;
	}

	public void PrepareBattle(string battleType, int battleId, int battleDifficulty, int enemyLvl)
	{
		KillSwitch.kill = false;
		INIParser ini = new INIParser();
		ini.Open(SetTarget.worldDataPath + "Battles/" + battleType + "/Difficulty" + battleDifficulty + "/" + battleType + battleId + ".ini");
		battleSystem.GetObjectives(ini.FileName);

		playerShip.transform.position = new Vector3(ini.ReadValue("InitialProperties", "PlayerPosX", 1), ini.ReadValue("InitialProperties", "PlayerPosY", 1), 0);

		PlayerMovementAlt.MaxYCoordinate = ini.ReadValue("InitialProperties", "Border_Ymax", 1);
		PlayerMovementAlt.MaxXCoordinate = ini.ReadValue("InitialProperties", "Border_Xmax", 1);
		PlayerMovementAlt.MinYCoordinate = ini.ReadValue("InitialProperties", "Border_Ymin", -1);
		PlayerMovementAlt.MinXCoordinate = ini.ReadValue("InitialProperties", "Border_Xmin", -1);

		for (int a = 1; a <= 256; a++)
		{
			GameObject instance = Instantiate(spawnables[ini.ReadValue("Object" + a, "id", 1)], new Vector3(ini.ReadValue("Object" + a, "PosX", 0), ini.ReadValue("Object" + a, "PosY", 0)), new Quaternion(), enemyGroup.transform);
			instance.GetComponent<ActiveObjectStats>().ObjectLevel = enemyLvl;
			instance.GetComponent<ActiveObjectStats>().SetStats();
			if (!ini.IsSectionExists("Object" + a))
			{
				a = 257;
			}
		}
		PrepareHud(false);
	}

	public void PrepareHud(bool setTo)
	{
		locationHud.SetActive(setTo);
	}

	public void EndBattle()
	{
		playerShip.transform.position = new Vector2(lastPosX, lastPosY);
		PrepareHud(true);
	}
}
