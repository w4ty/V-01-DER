using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InfoMenu : MonoBehaviour
{
	public GameObject menuCanvas;
	public Button dummyButton;
	public Button buttonContinue;
	public Button buttonQuit;
	public Text infoBar;
	public Text infoDesc;
	public Text levelInfo;
	public static bool isHidden = true;
	public int buttonCD;

	void Update()
	{
		if (buttonCD > 0)
		{
			buttonCD -= 1;
		}
		if (Input.GetButtonDown("Triangle") && isHidden == true && buttonCD <= 0 && DialogueManager.playerTalking == false)
		{
			showMenu();
			buttonCD = 100;
		}
		if (Input.GetButtonDown("Triangle") && isHidden == false && buttonCD <= 0 && DialogueManager.playerTalking == false)
		{
			hideMenu();
			buttonCD = 100;
		}
		levelInfo.text = "Current ship level:\n" + GameObject.Find("Player_Ship_a").GetComponent<PlayerStatistics>().shipLVL + "\n" + "Experience for next level up:\n" + GameObject.Find("Player_Ship_a").GetComponent<PlayerStatistics>().currentXP + "/" + GameObject.Find("Player_Ship_a").GetComponent<PlayerStatistics>().nextXP;
	}
	public void showMenu()
	{
		Pause.pauseOn = true;
		infoBar.text = QuestHandler.questName + " pt. " + QuestHandler.questPart + ".";
		infoDesc.text = QuestHandler.questDesc;
		menuCanvas.SetActive(true);
		isHidden = false;
		dummyButton.interactable = false;
		buttonContinue.interactable = true;
		buttonQuit.interactable = true;
		buttonContinue.Select();
	}
	public void hideMenu()
	{
		Pause.pauseOn = false;
		/*dummyButton.interactable = true;
		buttonContinue.interactable = false;
		buttonQuit.interactable = false;
		dummyButton.Select();*/
		menuCanvas.SetActive(false);
		isHidden = true;
	}

	public void ToMain()
	{
		SceneManager.LoadScene("Main_Menu");
	}
}
