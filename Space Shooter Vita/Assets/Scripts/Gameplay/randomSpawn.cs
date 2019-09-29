using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RandomSpawn : MonoBehaviour
{
	public GameObject[] spawnableUnits;
	public int[] spawnCooldowns;
	public int[] initialCooldowns;


	void FixedUpdate()
	{
		for (int i = 0; i < spawnCooldowns.Length; i++)
		{
			if (spawnCooldowns[i] <= 0)
			{
				Instantiate(spawnableUnits[i], this.transform.position, this.transform.rotation);
				spawnCooldowns[i] = initialCooldowns[i];
			}
		}
		StartCoroutine(SpawnCooldown());
	}

	IEnumerator SpawnCooldown()
	{
		for(int i=0; i < spawnCooldowns.Length; i++)
		{
			spawnCooldowns[i]--;
			yield return new WaitForSeconds(1f);
		}
	}
}
