using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChoiceButton : MonoBehaviour
{
	public string option;
	public DialogueManager box;

	public void SetText(string newText)
	{
		this.GetComponentInChildren<Text>().text = newText;
	}
	public void SetOption(string newOption)
	{
		this.option = newOption;
	}
	public void ParseOptions()
	{
		string command = option.Split(',')[0];
		string commandModifier = option.Split(',')[1];
		//DialogueManager.playerTalking = false;
		if (command == "line")
		{
			box.lineNum = int.Parse(commandModifier);

			box.ShowDialogue(box.lineNum);
			//DialogueManager.playerTalking = false;
		}
		else if (command == "scene")
		{
			SceneManager.LoadScene(commandModifier);
		}
		//DialogueManager.playerTalking = false;
	}
}
