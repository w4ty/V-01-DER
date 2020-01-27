using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLeveling : MonoBehaviour 
{
	public int objectLevel;
	ActiveObjectStats stats;

	void Start()
	{
		stats = this.gameObject.GetComponent<ActiveObjectStats>();
		CalculateStats();
	}



	void CalculateStats() 
	{
		stats.objectArmour += Mathf.RoundToInt((objectLevel / 10) * stats.armorScaleMX);
		stats.objectMaxHp += Mathf.RoundToInt((objectLevel / 10) * stats.hpScaleMX);
		stats.objectDamage += Mathf.RoundToInt((objectLevel / 10) * stats.damageScaleMX);
	}
}
