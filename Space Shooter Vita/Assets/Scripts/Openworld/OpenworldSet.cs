using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenworldSet : MonoBehaviour
{
	public GameObject portal1;
	public GameObject playerShip;
	public GameObject openWorldPlanets;
	static public string worldName = "MAINVOID";
	INIParser wINFO = new INIParser();

	public void OpenWorldStart ()
	{
		this.GetComponent<BattleHandler>().EndBattle();
		openWorldPlanets.SetActive(true);
		WorldAction.worldName = worldName;
		wINFO.Open(SetTarget.worldDataPath + "Worlds/" + worldName + "/Planets/planets.ini");
		PlayerMovementAlt.maxYCoordinate = 50;
		PlayerMovementAlt.maxXCoordinate = 50;
		PlayerMovementAlt.minYCoordinate = -50;
		PlayerMovementAlt.minXCoordinate = -50;
	}
	
	public void BattleStart ()
	{
			openWorldPlanets.SetActive(false);
			this.GetComponent<BattleHandler>().PrepareBattle();
	}
}
