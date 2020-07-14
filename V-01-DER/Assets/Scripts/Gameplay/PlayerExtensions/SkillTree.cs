using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillTree : MonoBehaviour
{
	public string treeName;
	public string statName;
	public int state;
	public int statId;
	public float[] levels;
	public int currentLvl;
	public float primBonus;
	public ActiveObjectStats playerStats;
	PlayerStatistics playerInfo;
	public Image bar;
	public Text levelText;

	void Start()
	{
		playerInfo = playerStats.gameObject.GetComponent<PlayerStatistics>();
		LevelUI();
	//	SetStats();
	}

	public void LevelUI()
	{
		levelText.text = currentLvl.ToString();
	}

	public void Upgrade()
	{
		if (currentLvl < 10 && playerInfo.skillPoints > 0)
		{
			playerInfo.skillPoints -= 1;
			currentLvl++;
			SetStats();
			bar.fillAmount += 0.1f;
			LevelUI();
		}
		else if (currentLvl < 10)
		{
			Debug.Log("Player doesn't have enough points!");
		}
		else if (currentLvl >= 10)
		{
			Debug.Log("Achieved max level for this skill tree!");
		}
	}

	public void SetStats()
	{
		if (currentLvl - 1 > -1)
		{
			switch (statId)
			{
				case (0):
					switch (state)
					{
						case (1):
							playerStats.objectFirerate = 2 + levels[currentLvl] + primBonus;
							break;
						default:
							playerStats.objectFirerate = 2 + levels[currentLvl];
							break;
						case (4):
							playerStats.objectFirerate = 2 + levels[currentLvl] / 2;
							break;
					}
					Debug.Log(playerStats.objectFirerate);
					break;
				case (1):
					switch (state)
					{
						case (1):
							playerStats.objectCritChance = 5 + levels[currentLvl] + primBonus;
							break;
						default:
							playerStats.objectCritChance = 5 + levels[currentLvl];
							break;
						case (4):
							playerStats.objectCritChance = 5 + levels[currentLvl] / 2;
							break;
					}
					Debug.Log(playerStats.objectCritChance);
					break;
				case (2):
					switch(state)
					{
						case (1):
							playerStats.objectDamage = 50 + Mathf.RoundToInt(levels[currentLvl] + primBonus);
							break;
						default:
							playerStats.objectDamage = 50 + Mathf.RoundToInt(levels[currentLvl]);
							break;
						case (4):
							playerStats.objectDamage = 50 + Mathf.RoundToInt(levels[currentLvl] / 2);
							break;
					}
					Debug.Log(playerStats.objectDamage);
					break;
				case (3):
					switch(state)
					{
						case (1):
							playerStats.objectCritDamage = 1.5f + levels[currentLvl] + primBonus;
							break;
						default:
							playerStats.objectCritDamage = 1.5f + levels[currentLvl];
							break;
						case (4):
							playerStats.objectCritDamage = 1.5f + levels[currentLvl] / 2;
							break;
					}
					Debug.Log(playerStats.objectCritDamage);
					break;
				case (4):
					switch (state)
					{
						case (1):
							playerStats.objectMaxHp = 100 + Mathf.RoundToInt(levels[currentLvl] + primBonus);
							break;
						default:
							playerStats.objectMaxHp = 100 + Mathf.RoundToInt(levels[currentLvl]);
							break;
						case (4):
							playerStats.objectMaxHp = 100 + Mathf.RoundToInt(levels[currentLvl] / 2);
							break;
					}
					Debug.Log(playerStats.objectMaxHp);
					break;
				case (5):
					switch (state)
					{
						case (1):
							playerStats.objectArmour = 2 + levels[currentLvl] + primBonus;
							break;
						default:
							playerStats.objectArmour = 2 + levels[currentLvl];
							break;
						case (4):
							playerStats.objectArmour = 2 + levels[currentLvl] / 2;
							break;
					}
					Debug.Log(playerStats.objectArmour);
					break;
			}
		}
	}
}
