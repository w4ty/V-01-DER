using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTarget : MonoBehaviour
{
	static public string controllerName;
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
	static public int versionGeneration = 1;
	static public int versionMajor = 4;
	static public int versionMinor = 1;
	static public int versionType = 4;
	static public string versionActual = versionGeneration + "." + versionMajor + "." + versionMinor + "." + versionType;

	// SetTarget.cs explanation.
	// SetTarget is used for better multiplat support by redirecting the game to proper file directories and setting various platform specific options.
	// If you want to port the game to a new platform, add a new case for the switch and put all of the dirs and settings there.
	// Remember to change the value of the targetPlatform string to your selected platform before building.

	void Awake()
	{
		switch (targetPlatform)
		{
			case "Windows":
				controllerName = "keyboard";
				maxUnits = 100;
				universalPath = Application.dataPath + "/StreamingAssets/";
				saveDataPath = Application.dataPath + "/StreamingAssets/SaveData/";
				worldDataPath = Application.dataPath + "/StreamingAssets/WorldData/";
				webDataPath = Application.dataPath + "/StreamingAssets/WebData/";
				dialDataPath = Application.dataPath + "/StreamingAssets/DialData/";
				break;
			case "PSVita":
				controllerName = "ps_generic";
				maxUnits = 50;
				universalPath = "ux0:data/V-01-DER/";
				saveDataPath = "ux0:data/V-01-DER/SaveData/";
				worldDataPath = "ux0:data/V-01-DER/WorldData/";
				webDataPath = "ux0:data/V-01-DER/WebData/";
				dialDataPath = "ux0:data/V-01-DER/DialData/";
				break;
		}
		Debug.Log(saveDataPath);
		Debug.Log(dialDataPath);
	}
}
