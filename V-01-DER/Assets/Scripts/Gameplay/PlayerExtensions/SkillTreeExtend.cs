using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillTreeExtend : MonoBehaviour
{
	public int primaryId = -1;
	public int secondaryId = -1;
	public int tertiaryId = -1;
	public SkillTree[] references;
	public int selectedId;
	public GameObject extendedButtons;
	public Text desc;
	string primaryName;
	string secondaryName;
	string tertiaryName;
	public string buildName;

	void Start()
	{
		ConstructBuild();
	}

	public void ConstructBuild()
	{
		switch (primaryId) 
		{
			case (0):
				primaryName = "Fast-Firing";
				break;
			case (1):
				primaryName = "Lucky";
				break;
			case (2):
				primaryName = "Stylish";
				break;
			case (3):
				primaryName = "Precise";
				break;
			case (4):
				primaryName = "Powerful";
				break;
			case (5):
				primaryName = "Undefeatable";
				break;
		}
		switch (secondaryId)
		{
			case (0):
				secondaryName = "Turret";
				break;
			case (1):
				secondaryName = "Outlaw";
				break;
			case (2):
				secondaryName = "Cowboy";
				break;
			case (3):
				secondaryName = "Sniper";
				break;
			case (4):
				secondaryName = "Juggernaut";
				break;
			case (5):
				secondaryName = "Lord";
				break;
		}
		switch (tertiaryId)
		{
			case (0):
				tertiaryName = "with Firepower";
				break;
			case (1):
				tertiaryName = "with Luck";
				break;
			case (2):
				tertiaryName = "with Style";
				break;
			case (3):
				tertiaryName = "with Virtuosity";
				break;
			case (4):
				tertiaryName = "with Strength";
				break;
			case (5):
				tertiaryName = "with Armor";
				break;
		}
		buildName = string.Format("{0} {1} {2}", primaryName, secondaryName, tertiaryName);
	}

	public void ExtendMenu(int id)
	{
		selectedId = id;
		extendedButtons.SetActive(true);
		DoDesc();
		ConstructBuild();
	}

	public void DoDesc()
	{
		desc.text = string.Format
			(
			"{0} lvl {1}\n{5} increased by {2}\nPrimary bonus: {3} (Active: {4})",
			references[selectedId].treeName, references[selectedId].currentLvl, references[selectedId].levels[references[selectedId].currentLvl], references[selectedId].primBonus, references[selectedId].state == 1, references[selectedId].statName
			);
	}

	public void Upgrade()
	{
		references[selectedId].Upgrade();
		DoDesc();
	}

	public void SetType(int which)
	{
		switch (which)
		{
			case (1):
				for (int i = 0; i < references.Length; i++)
				{
					if (references[i].state == 1)
					{
						references[i].state = 4;
					}
				}
				references[selectedId].state = 1;
				primaryId = selectedId;
				break;
			case (2):
				for (int i = 0; i < references.Length; i++)
				{
					if (references[i].state == 2)
					{
						references[i].state = 4;
					}
				}
				references[selectedId].state = 2;
				secondaryId = selectedId;
				break;
			case (3):
				for (int i = 0; i < references.Length; i++)
				{
					if (references[i].state == 3)
					{
						references[i].state = 4;
					}
				}
				references[selectedId].state = 3;
				tertiaryId = selectedId;
				break;
		}
		if(primaryId == selectedId)
		{
			references[selectedId].state = 1;
		}
		for (int i = 0; i < references.Length; i++)
		{
			references[i].SetStats();
			DoDesc();
		}
		ConstructBuild();
	}
}
