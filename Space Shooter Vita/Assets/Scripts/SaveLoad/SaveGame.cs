using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

public class SaveGame : MonoBehaviour
{
	string path;

	void SavePlayerStats()
	{
		/*path = Application.dataPath + "/StreamingAssets/Save/save_playerstats.txt";
		StreamWriter w = new StreamWriter(path, false);
		w.WriteLine(playerShip.GetComponent<PlayerStatistics>().shipLVL);
		w.WriteLine(playerShip.GetComponent<PlayerStatistics>().currentXP);
		w.WriteLine(playerShip.GetComponent<PlayerStatistics>().perkSelected);
		w.Close();*/
		INIParser ini = new INIParser();
		ini.Open(SetTarget.saveDataPath + "savedata_player.ini");
		ini.WriteValue("Player_Stats", "stt_shiplvl", this.GetComponent<PlayerStatistics>().shipLVL);
		ini.WriteValue("Player_Stats", "stt_xp", this.GetComponent<PlayerStatistics>().currentXP);
		ini.WriteValue("Player_Stats", "stt_perk", this.GetComponent<PlayerStatistics>().perkSelected);
		ini.Close();
	}

	void SavePlayerInfo()
	{
		INIParser ini = new INIParser();
		ini.Open(SetTarget.saveDataPath + "savedata_player.ini");
		ini.WriteValue("Player_Info", "last_x", Mathf.RoundToInt(this.transform.position.x));
		ini.WriteValue("Player_Info", "last_y", Mathf.RoundToInt(this.transform.position.y));
		ini.Close();
	}

	void Update()
	{
		if (Input.GetButtonUp("Triangle"))
		{
			SavePlayerStats();
			SavePlayerInfo();
		}
	}
}
