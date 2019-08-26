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
		ini.Open(SetTarget.saveDataPath + "savedata_player.ini");
		shipLvl = ini.ReadValue("Player_Stats", "stt_shiplvl", -1);
		xp = ini.ReadValue("Player_Stats", "stt_xp", -1);
		perk = ini.ReadValue("Player_Stats", "stt_perk", -1);
		ini.Close();
	}

	public void LoadPlayerInfo()
	{
		INIParser ini = new INIParser();
		ini.Open(SetTarget.saveDataPath + "savedata_player.ini");
		pos = new Vector3(ini.ReadValue("Player_Info", "last_x", 0), ini.ReadValue("Player_Info", "last_y", 0), 0);
		ini.Close();
	}

	public void QueueLoad()
	{
		queueLoad = true;
	}
}
