using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeScreen : MonoBehaviour
{
	public GameObject playerShip;
	ActiveObjectStats playerStats;
	PlayerStatistics playerInfo;
	SkillTreeExtend skillTreeExtend;
	public Text levelPoints;
	public Text stats;

	void OnEnable()
	{
		playerStats = playerShip.GetComponent<ActiveObjectStats>();
		playerInfo = playerShip.GetComponent<PlayerStatistics>();
		skillTreeExtend = GetComponent<SkillTreeExtend>();
		DoUI();
	}

	public void DoUI()
	{
		levelPoints.text = string.Format("Level {0}\nAvailable points {1}\nPrimary {2}\nSecondary {3}\nTertiary {4}\n{5}", playerInfo.shipLVL, playerInfo.skillPoints, skillTreeExtend.references[skillTreeExtend.primaryId].treeName, skillTreeExtend.references[skillTreeExtend.secondaryId].treeName, skillTreeExtend.references[skillTreeExtend.tertiaryId].treeName, skillTreeExtend.buildName);
		stats.text = string.Format("Health {0}\nArmor {1}\nDamage {2}\nFirerate {3}\nCrit chance {4}%\nCrit damage {5}%", playerStats.objectMaxHp, playerStats.objectArmour, playerStats.objectDamage, playerStats.objectFirerate, playerStats.objectCritChance, playerStats.objectCritDamage * 100);
	}
}
