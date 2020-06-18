using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchHandler : MonoBehaviour 
{
	INIParser ini = new INIParser();
	static public int locID;
	static public int reqID;

	public void ParseOption(int id, GameObject button)
	{
		ini.Open(SetTarget.worldDataPath + "Worlds/" + LocationHandler.worldName + "/Planets/planets.ini");
		reqID = ini.ReadValue("Planet" + locID, "button" + id, 0);
		switch (reqID)
		{
			case 0:
				Debug.Log("case 0");
				//button.GetComponent<Text>().text = ini.ReadValue("BUTTONID" + reqID, "text", "");
				GameObject.Find("WorldMaster").GetComponent<WorldAction>().DoOutAnim();
				break;
			case 101:
				Debug.Log("case 101");
				break;
			case 401:
				Debug.Log("case 401");
				GameObject.Find("WorldMaster").GetComponent<WorldAction>().DestroyButtons();
				GameObject.Find("WorldMaster").GetComponent<OpenworldSet>().BattleStart(ini.ReadValue("Planet" + locID, "battle_type", "Generic"), Random.Range(ini.ReadValue("Planet" + locID, "battle_id_low", 0), ini.ReadValue("Planet" + locID, "battle_id_high", 0)), ini.ReadValue("Planet" + locID, "battle_difficulty", 1));
				break;
		}

	}
}
