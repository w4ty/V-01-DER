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
		this.GetComponent<LoadGame>().LoadPlayerStats();
		this.GetComponent<LoadGame>().LoadPlayerInfo();
		this.GetComponent<LoadGame>().QueueLoad();
		SceneManager.LoadScene("Gameplay_Battle");
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
