using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestHandler : MonoBehaviour
{
	public static QuestHandler Instance;
	public string questName;
	public int questID;
	public int questPart;
	public int questScene;
	public string questDesc;
	public string questType;
	public int questState;
	public GameObject[] quests;
	private Quest currentQuest;

	private void Awake()
	{
		Instance = this;
	}

	private void Start()
	{
	//	SetQuest(0);
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
