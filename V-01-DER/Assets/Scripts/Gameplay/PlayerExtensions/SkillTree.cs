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
							playerStats.ObjectFirerate = 2 + levels[currentLvl] + primBonus;
							break;
						default:
							playerStats.ObjectFirerate = 2 + levels[currentLvl];
							break;
						case (4):
							playerStats.ObjectFirerate = 2 + levels[currentLvl] / 2;
							break;
					}
					Debug.Log(playerStats.ObjectFirerate);
					break;
				case (1):
					switch (state)
					{
						case (1):
							playerStats.ObjectCritChance = 5 + levels[currentLvl] + primBonus;
							break;
						default:
							playerStats.ObjectCritChance = 5 + levels[currentLvl];
							break;
						case (4):
							playerStats.ObjectCritChance = 5 + levels[currentLvl] / 2;
							break;
					}
					Debug.Log(playerStats.ObjectCritChance);
					break;
				case (2):
					switch(state)
					{
						case (1):
							playerStats.ObjectDamage = 50 + Mathf.RoundToInt(levels[currentLvl] + primBonus);
							break;
						default:
							playerStats.ObjectDamage = 50 + Mathf.RoundToInt(levels[currentLvl]);
							break;
						case (4):
							playerStats.ObjectDamage = 50 + Mathf.RoundToInt(levels[currentLvl] / 2);
							break;
					}
					Debug.Log(playerStats.ObjectDamage);
					break;
				case (3):
					switch(state)
					{
						case (1):
							playerStats.ObjectCritDamage = 1.5f + levels[currentLvl] + primBonus;
							break;
						default:
							playerStats.ObjectCritDamage = 1.5f + levels[currentLvl];
							break;
						case (4):
							playerStats.ObjectCritDamage = 1.5f + levels[currentLvl] / 2;
							break;
					}
					Debug.Log(playerStats.ObjectCritDamage);
					break;
				case (4):
					switch (state)
					{
						case (1):
							playerStats.ObjectMaxHp = 100 + Mathf.RoundToInt(levels[currentLvl] + primBonus);
							break;
						default:
							playerStats.ObjectMaxHp = 100 + Mathf.RoundToInt(levels[currentLvl]);
							break;
						case (4):
							playerStats.ObjectMaxHp = 100 + Mathf.RoundToInt(levels[currentLvl] / 2);
							break;
					}
					Debug.Log(playerStats.ObjectMaxHp);
					break;
				case (5):
					switch (state)
					{
						case (1):
							playerStats.ObjectArmour = 2 + levels[currentLvl] + primBonus;
							break;
						default:
							playerStats.ObjectArmour = 2 + levels[currentLvl];
							break;
						case (4):
							playerStats.ObjectArmour = 2 + levels[currentLvl] / 2;
							break;
					}
					Debug.Log(playerStats.ObjectArmour);
					break;
			}
		}
	}
}
