using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadGame : MonoBehaviour
{
	public GameObject playerShip;
	string path;

	public void LoadPlayerStats()
	{
		INIParser ini = new INIParser();
		ini.Open(Application.dataPath + "/StreamingAssets/Save/savedata_player.ini");
		playerShip.GetComponent<PlayerStatistics>().shipLVL = ini.ReadValue("Player_Stats", "stt_shiplvl", -1);
		playerShip.GetComponent<PlayerStatistics>().currentXP = ini.ReadValue("Player_Stats", "stt_xp", -1);
		playerShip.GetComponent<PlayerStatistics>().perkSelected = ini.ReadValue("Player_Stats", "stt_perk", -1);
		ini.Close();
	}

	public void LoadPlayerInfo()
	{
		INIParser ini = new INIParser();
		ini.Open(Application.dataPath + "/StreamingAssets/Save/savedata_player.ini");
		playerShip.transform.position = new Vector3(ini.ReadValue("Player_Info", "last_x", 0), ini.ReadValue("Player_Info", "last_y", 0), 0);
		ini.Close();
	}
}
