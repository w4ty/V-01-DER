using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{

	public void BeginGame()
	{
		SceneManager.LoadScene("Gameplay_Battle");
		QuestHandler.Prologue();
	}
	public void LoadSave()
	{
		Debug.Log("Loading not yet implemented.");
	}
	public void OpenOptions()
	{
		Debug.Log("Options not yet implemented.");
	}
	public void ShowCredits()
	{
		Debug.Log("Credits not yet implemented.");
	}
}
