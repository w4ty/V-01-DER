using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadGame : MonoBehaviour
{
	string path;
	static public int shipLvl;
	static public int xp;
	static public int perk;
	static public Vector3 pos;
	static public bool queueLoad;

	public void LoadPlayerStats()
	{
		INIParser ini = new INIParser();
		ini.Open(SetTarget.saveDataPath + SetTarget.saveDataName);
		shipLvl = ini.ReadValue("PlayerStatistics", "shipLVL", -1);
		xp = ini.ReadValue("PlayerStatistics", "currentXP", -1);
		perk = ini.ReadValue("PlayerStatistics", "perkSelected", -1);
		ini.Close();
	}

	public void LoadPlayerInfo()
	{
		INIParser ini = new INIParser();
		ini.Open(SetTarget.saveDataPath + SetTarget.saveDataName);
		pos = new Vector3(ini.ReadValue("InstanceInfo", "last_x", 0) / 10, ini.ReadValue("InstanceInfo", "last_y", 0) / 10, 0);
		ini.Close();
	}

	public void QueueLoad()
	{
		queueLoad = true;
	}
}
