using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleSystem : MonoBehaviour
{
	public int objectiveAmount;
	public Text objectiveText;
	public GameObject enemyGroup;
	public GameObject worldMaster;
	public GameObject endBattleGroup;
	private string[] objToDestroy;
	private int[] objAmountToDestroy;
	private int[] objPlayerDone;
	private bool[] objectiveDone;
	private string[] textArray;
	private bool allDone;
	INIParser matiaz = new INIParser();
	string textToParse;
	string repText;


	void Start()
	{
		objectiveText = GameObject.Find("objectiveText").GetComponent<Text>();
		//objectiveText.text = "Battle objectives: \n";
	}

	public void GetObjectives(string path)
	{
		//Debug.LogError(path);
		matiaz.Open(path);
		//Debug.LogError(matiaz.FileName);
		if (matiaz.ReadValue("InitialProperties", "ObjectiveType", -1) == 0)
		{
			objectiveAmount = matiaz.ReadValue("InitialProperties", "Objectives", 0);
			objToDestroy = new string[objectiveAmount];
			objAmountToDestroy = new int[objectiveAmount];
			objPlayerDone = new int[objectiveAmount];
			objectiveDone = new bool[objectiveAmount];
			DamageHandler.objAmount = objectiveAmount;
			for (int objA = 0; objA < objectiveAmount; objA++)
			{
				objToDestroy[objA] = matiaz.ReadValue(string.Format("Objective{0}", (objA + 1)), "ObjToDestroy", "nullObject");
				objAmountToDestroy[objA] = matiaz.ReadValue(string.Format("Objective{0}", (objA + 1)), "ObjAmountToDestroy", 0);
				UpdateObjective();
			}
		}
		DamageHandler.objToSeek = objToDestroy;
	}

	public void ObjectiveAdd(string name, int objID)
	{
		objPlayerDone[objID] += 1;
		UpdateObjective();
	}

	public void UpdateObjective()
	{
		textArray = new string[objectiveAmount];
		objectiveText.text = "Battle objectives: \n";
		for (int objA = 0; objA < objectiveAmount; objA++)
		{
			textArray[objA] = string.Format("Destroy {0} {1}/{2}\n", objToDestroy[objA], objPlayerDone[objA], objAmountToDestroy[objA]);
			objectiveText.text += textArray[objA];
			if (objPlayerDone[objA] >= objAmountToDestroy[objA])
			{
				objectiveDone[objA] = true;
			}
			else
			{
				objectiveDone[objA] = false;
			}
			Debug.Log(string.Format("Objective {0} done: {1}", objA, objectiveDone[objA]));
			allDone = true;
			for (int i = 0; i < objectiveDone.Length; i++)
			{
				if (objectiveDone[i] == false)
				{
					allDone = false;
					break;
				}
			}
			Debug.Log(string.Format("All done? {0}", allDone));
			if (allDone == true)
			{
				allDone = false;
				Array.Clear(objectiveDone, 0, objectiveDone.Length);
				Pause.pauseOn = true;
				endBattleGroup.SetActive(true);
				endBattleGroup.GetComponentInChildren<Button>().Select();
				KillChildren();
				this.GetComponent<BattleRewards>().DropLoot(matiaz.ReadValue("Rewards", "BonusItemTable", 0), matiaz.ReadValue("Rewards", "BonusExp", 0));
				Debug.Log("EXP " + matiaz.ReadValue("Rewards", "BonusExp", 0));
			}
		}
	}

	public void EndBattle()
	{
		this.GetComponent<BattleRewards>().DestroyButtons();
	}

	public void SwitchAfterEnd()
	{
		objectiveText.text = "";
		Pause.pauseOn = false;
		worldMaster.GetComponent<OpenworldSet>().OpenWorldStart();
		endBattleGroup.SetActive(false);
	}

	void KillChildren()
	{
		foreach (Transform child in enemyGroup.transform)
		{
			GameObject.Destroy(child.gameObject);
		}
	}
}