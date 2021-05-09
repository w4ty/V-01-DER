using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenworldSet : MonoBehaviour
{
	public GameObject portal1;
	public GameObject playerShip;
	public GameObject openWorldPlanets;
	public GameObject planetPrefab;
	static public string worldName = "Void I - Main";
	INIParser wINFO = new INIParser();

	public void LoadWorld()
	{
		PlayerMovementAlt.MaxYCoordinate = wINFO.ReadValue("WorldProperties", "maxY", 0);
		PlayerMovementAlt.MinYCoordinate = wINFO.ReadValue("WorldProperties", "minY", 0);
		PlayerMovementAlt.MaxXCoordinate = wINFO.ReadValue("WorldProperties", "maxX", 0);
		PlayerMovementAlt.MinXCoordinate = wINFO.ReadValue("WorldProperties", "minX", 0);
		for (int i = 1; i <= wINFO.ReadValue("WorldProperties", "planets", 0); i++)
		{
			Debug.Log(wINFO.ReadValue(string.Format("Planet{0}", i), "pos_x", 0) + "/" + wINFO.ReadValue(string.Format("Planet{0}", i), "pos_y", 0) + "/Planet" + i);
			Vector3 pos = new Vector3(wINFO.ReadValue(string.Format("Planet{0}", i), "pos_x", 0), wINFO.ReadValue(string.Format("Planet{0}", i), "pos_y", 0));
			GameObject planet = Instantiate(planetPrefab, pos, transform.rotation, openWorldPlanets.transform);
			planet.transform.SetParent(openWorldPlanets.transform, true);
			LocationHandler locHandle = planet.GetComponent<LocationHandler>();
			locHandle.locationID = i;
			planet.GetComponent<SpriteRenderer>().sprite = openWorldPlanets.GetComponent<PlanetSprites>().ReturnSprite(wINFO.ReadValue(string.Format("Planet{0}", i), "sprite", 0));
		}
	}

	public void OpenWorldStart()
	{
		this.GetComponent<BattleHandler>().EndBattle();
		SetPlanets(true);
		WorldAction.worldName = worldName;
		wINFO.Open(SetTarget.worldDataPath + "Worlds/" + worldName + "/Planets/planets.ini");
		LoadWorld();
	}

	public void BattleStart(string battleType, int battleId, int battleDifficulty, int enemyLvl)
	{
		SetPlanets(false);
		this.GetComponent<BattleHandler>().PrepareBattle(battleType, battleId, battleDifficulty, enemyLvl);
	}

	public void SetPlanets(bool setTo)
	{
		openWorldPlanets.SetActive(setTo);
	}
}
