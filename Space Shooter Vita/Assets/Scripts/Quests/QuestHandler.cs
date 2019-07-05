using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestHandler : MonoBehaviour
{
	public static string questName = "Placeholder Quest";
	public static int questID = 0;
	public static int questPart = 1;

	public static void Prologue()
	{
		questName = "Prologue";
		questID = 1;
		questPart = 1;
	}
}
