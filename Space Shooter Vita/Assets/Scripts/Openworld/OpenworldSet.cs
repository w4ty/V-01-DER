using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenworldSet : MonoBehaviour
{
	public GameObject portal1;
	public GameObject playerShip;
	public GameObject openWorldPlanets;

	public void OpenWorldStart ()
	{
		playerShip.GetComponent<PlayerMovementAlt>().maxYCoordinate = 50;
		playerShip.GetComponent<PlayerMovementAlt>().maxXCoordinate = 50;
		playerShip.GetComponent<PlayerMovementAlt>().minYCoordinate = -50;
		playerShip.GetComponent<PlayerMovementAlt>().minXCoordinate = -50;
	}
	
	public void BattleStart ()
	{
		if(LocationHandler.selectedLoc == 1)
		{
			openWorldPlanets.SetActive(false);
			playerShip.GetComponent<PlayerMovementAlt>().maxYCoordinate = 20;
			playerShip.GetComponent<PlayerMovementAlt>().maxXCoordinate = 20;
			playerShip.GetComponent<PlayerMovementAlt>().minYCoordinate = -20;
			playerShip.GetComponent<PlayerMovementAlt>().minXCoordinate = -20;
			Instantiate(portal1, new Vector3(-5, 5, 0), Quaternion.identity);
		}
	}
}
