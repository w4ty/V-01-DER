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
		stats.ObjectArmour += Mathf.RoundToInt((objectLevel / 10) * stats.ArmourScaleMX);
		stats.ObjectMaxHp += Mathf.RoundToInt((objectLevel / 10) * stats.HpScaleMX);
		stats.ObjectDamage += Mathf.RoundToInt((objectLevel / 10) * stats.DamageScaleMX);
	}
}
