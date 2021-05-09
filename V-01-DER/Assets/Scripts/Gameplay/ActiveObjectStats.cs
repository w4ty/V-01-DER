using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveObjectStats : MonoBehaviour
{
	public float HpScaleMX;
	public float ArmourScaleMX;
	public float FirerateScaleMX;
	public float CritChanceScaleMX;
	public float CritDamageScaleMX;
	public float DamageScaleMX;
	[System.NonSerialized] public string ObjectName;
	[System.NonSerialized] public int ObjectDamage;
	[System.NonSerialized] public float ObjectFirerate;
	[System.NonSerialized] public float ObjectCritChance;
	[System.NonSerialized] public float ObjectCritDamage;
	[System.NonSerialized] public float ObjectArmour;
	[System.NonSerialized] public int ObjectMaxHp;
	[System.NonSerialized] public int ObjectLevel;
	private ObjectStats objectStats;

	public void SetStats()
	{
		objectStats = GetComponent<ObjectStats>();
		ObjectName = objectStats.ObjectName;
		ObjectMaxHp = Mathf.RoundToInt(objectStats.ObjectMaxHp * (1 + (HpScaleMX * ObjectLevel)));
		ObjectDamage = Mathf.RoundToInt(objectStats.ObjectDamage * (1 + (DamageScaleMX * ObjectLevel)));
		ObjectArmour = objectStats.ObjectArmour * (1 + ArmourScaleMX * ObjectLevel);
		ObjectFirerate = objectStats.ObjectFirerate * (1 + (FirerateScaleMX * ObjectLevel));
		ObjectCritChance = objectStats.ObjectCritChance * (1 + CritChanceScaleMX * ObjectLevel);
		ObjectCritDamage = objectStats.ObjectCritDamage * (1 + CritDamageScaleMX * ObjectLevel);
	}
}
