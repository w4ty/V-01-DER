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
				objToDestroy[objA] = matiaz.ReadValue("Objective" + (objA + 1), "ObjToDestroy", "nullObject");
				objAmountToDestroy[objA] = matiaz.ReadValue("Objective" + (objA + 1), "ObjAmountToDestroy", 0);
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
		objectiveText.text = "";
		for (int objA = 0; objA < objectiveAmount; objA++)
		{
			textArray[objA] = "Destroy " + objToDestroy[objA] + " " + objPlayerDone[objA] + "/" + objAmountToDestroy[objA] + "\n";
			objectiveText.text += textArray[objA];
			if (objPlayerDone[objA] >= objAmountToDestroy[objA])
			{
				objectiveDone[objA] = true;
			}
			else
			{
				objectiveDone[objA] = false;
			}
			Debug.Log("Objective " + objA + " done: " + objectiveDone[objA]);
			allDone = true;
			for (int i = 0; i < objectiveDone.Length; i++)
			{
				if (objectiveDone[i] == false)
				{
					allDone = false;
					break;
				}
			}
			Debug.Log("All done? " + allDone);
			if (allDone == true)
			{
				KillChildren();
				worldMaster.GetComponent<OpenworldSet>().OpenWorldStart();
			}
		}
	}

	void KillChildren()
	{
		foreach (Transform child in enemyGroup.transform)
		{
			GameObject.Destroy(child.gameObject);
		}
	}
}