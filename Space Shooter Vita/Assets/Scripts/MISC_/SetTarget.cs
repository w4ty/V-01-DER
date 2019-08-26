using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTarget : MonoBehaviour
{
	static public string lang = "English";
	static public int maxUnits;
	static public string targetPlatform = "Windows";
	static public string saveDataPath;
	static public string worldDataPath;
	static public string universalPath;
	static public string webDataPath;
	static public string dialDataPath;
	static public string buildType = "Alpha";
	static public string buildName = "";
	static public int versionGeneration = 0;
	static public int versionMajor = 5;
	static public int versionMinor = 0;
	static public int versionType = 4;
	static public string versionActual = versionGeneration + "." + versionMajor + "." + versionMinor + "." + versionType;

	void Awake()
	{
		if (targetPlatform == "PSVita")
		{
			maxUnits = 50;
			universalPath = "ux0:data/V-01-DER/";
			saveDataPath = "ux0:data/V-01-DER/SaveData/";
			worldDataPath = "ux0:data/V-01-DER/WorldData/";
			webDataPath = "ux0:data/V-01-DER/WebData/";
			dialDataPath = "ux0:data/V-01-DER/DialData/";
		}
		else if (targetPlatform == "Windows")
		{
			maxUnits = 100;
			universalPath = Application.dataPath + "/StreamingAssets/";
			saveDataPath = Application.dataPath + "/StreamingAssets/SaveData/";
			worldDataPath = Application.dataPath + "/StreamingAssets/WorldData/";
			webDataPath = Application.dataPath + "/StreamingAssets/WebData/";
			dialDataPath = Application.dataPath + "/StreamingAssets/DialData/";
		}
		Debug.Log(saveDataPath);
	}
}
