using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTarget : MonoBehaviour
{
	static public string targetPlatform = "PSVita";
	static public string saveDataPath;

	void Start ()
	{
		if (targetPlatform == "PSVita")
		{
			saveDataPath = "ux0:data/V-01-DER/SaveData/savedata_player.ini";
		}
		else if (targetPlatform == "Windows")
		{
			saveDataPath = Application.dataPath + "/StreamingAssets/SaveData/savedata_player.ini";
		}
	}
}
