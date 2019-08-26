using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
	public GameObject UnitToSpawn;
	public GameObject UnitToSpawn2;
//	public GameObject UnitToSpawn3;
	public GameObject Portal;
	public float spawnCD;
	public float spawnCD2;
	//	public float spawnCD3;
	int enemyCount1;
	int enemyCount2;


	void Update ()
	{
		spawnCD -= 1;
		if (spawnCD <= 0 && SetTarget.maxUnits > enemyCount2 + enemyCount1)
		{
			spawnCD = 180f;
			Instantiate(UnitToSpawn, Portal.transform.position, transform.rotation);
		}
		spawnCD2 -= 1;
		if (spawnCD2 <= 0 && SetTarget.maxUnits > enemyCount2 + enemyCount1)
		{
			spawnCD2 = 240f;
			Instantiate(UnitToSpawn2, Portal.transform.position, transform.rotation);
		}
		enemyCount1 = GameObject.FindGameObjectsWithTag("Enemy1").Length;
		enemyCount2 = GameObject.FindGameObjectsWithTag("Enemy2").Length;
		Debug.Log("NObjects " + (enemyCount1 + enemyCount2));
		/* spawnCD3 -= 1;
		if (spawnCD3 <= 0)
		{
			spawnCD3 = 180f;
			Instantiate(UnitToSpawn3, Portal.transform.position, transform.rotation);
		}
		*/
	}
}
