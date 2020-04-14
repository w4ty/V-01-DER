using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Reflection;

public class Quest : MonoBehaviour
{
	public string questName;
	public int questID;
	public int questPart;
	public int questScene;
	public string questDesc;
	public string questType;
	public int questState;
	private QuestHandler questHandler;

	private void Start()
	{
		questHandler = GameObject.Find("QuestHandler").GetComponent<QuestHandler>();
	}

	public void CallForGet()
	{
		questHandler.GetData();
	}
}
