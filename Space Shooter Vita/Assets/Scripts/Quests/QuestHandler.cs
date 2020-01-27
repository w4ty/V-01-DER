using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestHandler : MonoBehaviour
{
	public static string questName = "Prologue";
	public static int questID = 0;
	public static int questPart = 1;
	public static int questScene = 1;
	public static string questDesc = "Placeholder quest description.";

	public static void Prologue()
	{
		questName = "Prologue";
		questID = 1;
		questPart = 1;
		questDesc = "You've awoken on an unknown ship in an unknown place. Time to find some answers.";
	}
}
