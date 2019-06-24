using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuButtons : MonoBehaviour {

	public void BeginGame()
	{
		SceneManager.LoadScene("Gameplay_Other");
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
