using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class SwitchHandler : MonoBehaviour 
{
	INIParser ini = new INIParser();
	static public int locID;
	static public int reqID;

	public void ParseOption(int id, GameObject button, string file, string group)
	{
		ini.Open(SetTarget.worldDataPath + "Worlds/" + OpenworldSet.worldName + "/Planets/" + file + ".ini");
		reqID = ini.ReadValue(group + locID, "button" + id, 0);
		switch (reqID)
		{
			case 0:
				Debug.Log("case 0");
				//button.GetComponent<Text>().text = ini.ReadValue("BUTTONID" + reqID, "text", "");
				GameObject.Find("WorldMaster").GetComponent<WorldAction>().DoOutAnim();
				ini.Close();
				break;
			case 101:
				Debug.Log("case 101");
				GameObject.Find("WorldMaster").GetComponent<BattleHandler>().SaveLastPos();
				GameObject.Find("WorldMaster").GetComponent<WorldAction>().DestroyButtons();
				GameObject.Find("WorldMaster").GetComponent<ExploreSet>().SetLocation(ini.ReadValue("Planet" + locID, "exname_id", -1));
				GameObject.Find("WorldMaster").GetComponent<OpenworldSet>().SetPlanets(false);
				ini.Close();
				break;
			case 401:
				Debug.Log("case 401");
				GameObject.Find("WorldMaster").GetComponent<BattleHandler>().SaveLastPos();
				GameObject.Find("WorldMaster").GetComponent<WorldAction>().DestroyButtons();
				GameObject.Find("WorldMaster").GetComponent<OpenworldSet>().BattleStart(ini.ReadValue("Planet" + locID, "battle_type", "Generic"), Random.Range(ini.ReadValue("Planet" + locID, "battle_id_low", 0), ini.ReadValue("Planet" + locID, "battle_id_high", 0) + 1), ini.ReadValue("Planet" + locID, "battle_difficulty", 1), ini.ReadValue("Planet" + locID, "enemy_difficulty", 1));
				ini.Close();
				break;
			case 1001:
				Debug.LogWarning("case 1001");
				GameObject.Find("WorldMaster").GetComponent<ExploreSet>().DestroyButtons();
				GameObject.Find("WorldMaster").GetComponent<ExploreSet>().EndLocation();
				GameObject.Find("WorldMaster").GetComponent<BattleHandler>().EndBattle();
				GameObject.Find("WorldMaster").GetComponent<OpenworldSet>().SetPlanets(true);
				ini.Close();
				break;
			case 102:
				GameObject.Find("WorldMaster").GetComponent<WorldAction>().DestroyButtons();
				GameObject.Find("WorldMaster").GetComponent<ExploreSet>().SetLocation(ini.ReadValue("Planet" + locID, "exname_id", -1));
				break;
		}

	}
}
