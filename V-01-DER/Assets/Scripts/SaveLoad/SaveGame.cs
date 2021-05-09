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
		INIParser ini = new INIParser();
		ini.Open(SetTarget.saveDataPath + SetTarget.saveDataName);
		ini.WriteValue("PlayerStatistics", "shipLVL", this.GetComponent<PlayerStatistics>().shipLVL);
		ini.WriteValue("PlayerStatistics", "currentXP", this.GetComponent<PlayerStatistics>().currentXP);
		ini.WriteValue("PlayerStatistics", "perkSelected", this.GetComponent<PlayerStatistics>().perkSelected);
		ini.Close();
	}

	void SaveProgress()
	{
		Debug.Log("Saving...");
		INIParser ini = new INIParser();
		ini.Open(SetTarget.saveDataPath + SetTarget.saveDataName);
		ini.WriteValue("PlayerStatistics", "shipLVL", this.GetComponent<PlayerStatistics>().shipLVL);
		ini.WriteValue("PlayerStatistics", "currentXP", this.GetComponent<PlayerStatistics>().currentXP);
		ini.WriteValue("PlayerStatistics", "perkSelected", this.GetComponent<PlayerStatistics>().perkSelected);
		ini.WriteValue("InstanceInfo", "last_x", Mathf.RoundToInt(this.transform.position.x * 10));
		ini.WriteValue("InstanceInfo", "last_y", Mathf.RoundToInt(this.transform.position.y * 10));
		ini.WriteValue("InstanceInfo", "seconds", GameTime.seconds);
		ini.WriteValue("InstanceInfo", "minutes", GameTime.minutes);
		ini.Close();
		Debug.Log("Progress saved!");
	}

	void SavePlayerInfo()
	{
		INIParser ini = new INIParser();
		ini.Open(SetTarget.saveDataPath + SetTarget.saveDataName);
		ini.WriteValue("Player_Info", "last_x", Mathf.RoundToInt(this.transform.position.x * 10));
		ini.WriteValue("Player_Info", "last_y", Mathf.RoundToInt(this.transform.position.y * 10));
		ini.Close();
	}

	void Update()
	{
		if (Input.GetKeyUp(KeyCode.F2))
		{
			SaveProgress();
		}
	}
}
