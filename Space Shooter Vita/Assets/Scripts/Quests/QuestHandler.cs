using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestHandler : MonoBehaviour
{
	public static string questName;
	public static int questID;
	public static int questPart;
	public static int questScene;
	public static string questDesc;
	public static string questType;
	public static int questState;
	public GameObject[] quests;
	private Quest currentQuest;

	public void Start()
	{
		//Quest.player = playerShip;
		//Quest.Prologue.OnQuestSet();
		SetQuest(0);
	}

	protected void SetQuest(int idToSet)
	{
		for (int i = 0; i < quests.Length; i++)
		{
			if (i == idToSet)
			{
				quests[idToSet].SetActive(true);
				currentQuest = quests[idToSet].GetComponent<Quest>();
				GetData();
			}
			else
			{
				quests[i].SetActive(false);
			}
		}
	}
	public void GetData()
	{
		questName = currentQuest.questName;
		questID = currentQuest.questID;
		questPart = currentQuest.questPart;
		questScene = currentQuest.questScene;
		questDesc = currentQuest.questDesc;
		questType = currentQuest.questType;
		questState = currentQuest.questState;
	}
}
