using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTarget : MonoBehaviour
{
	static public string targetPlatform = "Windows";
	static public string saveDataPath;
	static public string dataDownPath;
	static public string universalPath;
	static public string buildType = "Alpha";
	static public string buildName = "";
	static public int versionGeneration = 0;
	static public int versionMajor = 5;
	static public int versionMinor = 0;
	static public int versionType = 4;
	static public string versionActual = versionGeneration + "." + versionMajor + "." + versionMinor + "." + versionType;

	void Start ()
	{
		if (targetPlatform == "PSVita")
		{
			universalPath = "ux0:data/V-01-DER/";
			saveDataPath = "ux0:data/V-01-DER/SaveData/savedata_player.ini";
			dataDownPath = "ux0:data/V-01-DER/web/";
		}
		else if (targetPlatform == "Windows")
		{
			universalPath = Application.dataPath + "/StreamingAssets/";
			saveDataPath = Application.dataPath + "/StreamingAssets/SaveData/savedata_player.ini";
			dataDownPath = Application.dataPath + "/StreamingAssets/web/";
		}
		Debug.Log(saveDataPath);
	}
}
