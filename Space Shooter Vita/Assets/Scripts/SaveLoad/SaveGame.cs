using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

public class SaveGame : MonoBehaviour
{

	public GameObject playerShip;
	string path;

	void OnSaveGamePSTATS()
	{
		/*path = Application.dataPath + "/StreamingAssets/Save/save_playerstats.txt";
		StreamWriter w = new StreamWriter(path, false);
		w.WriteLine(playerShip.GetComponent<PlayerStatistics>().shipLVL);
		w.WriteLine(playerShip.GetComponent<PlayerStatistics>().currentXP);
		w.WriteLine(playerShip.GetComponent<PlayerStatistics>().perkSelected);
		w.Close();*/
		INIParser ini = new INIParser();
		ini.Open(Application.dataPath + "/StreamingAssets/Save/savedata_player.ini");
		ini.WriteValue("Player_Stats", "stt_shiplvl", playerShip.GetComponent<PlayerStatistics>().shipLVL);
		ini.WriteValue("Player_Stats", "stt_xp", playerShip.GetComponent<PlayerStatistics>().currentXP);
		ini.WriteValue("Player_Stats", "stt_perk", playerShip.GetComponent<PlayerStatistics>().perkSelected);
		ini.Close();
	}
	void Update()
	{
		if (Input.GetButtonUp("Triangle"))
		{
			OnSaveGamePSTATS();
		}
	}
}
