using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomSpawn : MonoBehaviour {
	public GameObject UnitToSpawn;
	public GameObject Portal;
	public float spawnCD;

	
	void Update () {
		spawnCD -= 1;
		if (spawnCD <= 0)
		{
			spawnCD = 180f;
			Instantiate(UnitToSpawn, Portal.transform.position, transform.rotation);
		}
	}
}
