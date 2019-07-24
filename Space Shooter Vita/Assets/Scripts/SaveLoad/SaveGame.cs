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
		path = Application.dataPath + "/StreamingAssets/Save/save_playerstats.txt";
		StreamWriter w = new StreamWriter(path, false);
		w.WriteLine(playerShip.GetComponent<PlayerStatistics>().shipLVL);
		w.WriteLine(playerShip.GetComponent<PlayerStatistics>().currentXP);
		w.WriteLine(playerShip.GetComponent<PlayerStatistics>().perkSelected);
		w.Close();
	}
	void Update()
	{
		if (Input.GetButtonUp("Triangle"))
		{
			OnSaveGamePSTATS();
		}
	}
}
