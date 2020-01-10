using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InfoMenu : MonoBehaviour
{
	GameObject pShip;
	public GameObject mainGroup;
	public GameObject loadoutGroup;
	PlayerStatistics pStats;
	public GameObject menuCanvas;
	public Button dummyButton;
	public Button buttonContinue;
	public Button buttonQuit;
	public Text infoBar;
	public Text infoDesc;
	public Text levelInfo;
	static public bool isHidden = true;
	public int buttonCD;

	void Start()
	{
		pShip = GameObject.Find("Player_Ship_a");
		pStats = pShip.GetComponent<PlayerStatistics>();
	}

	void Update()
	{
		if (buttonCD > 0)
		{
			buttonCD -= 1;
		}
		if (Input.GetButtonDown("Triangle") && isHidden == true && buttonCD <= 0 && DialogueManager.playerTalking == false)
		{
			ShowMenu();
			buttonCD = 100;
		}
		if (Input.GetButtonDown("Triangle") && isHidden == false && buttonCD <= 0 && DialogueManager.playerTalking == false && CameraSwitcher.screenshotEnabled == false)
		{
			HideMenu();
			buttonCD = 100;
		}
		if (!isHidden && pShip)
		{
			levelInfo.text = "Current ship level:\n" + pStats.shipLVL + "\n" + "Experience for next:\n" + pStats.currentXP + "/" + pStats.nextXP;
		}
	}
	public void ShowMenu()
	{
		Pause.pauseOn = true;
		infoBar.text = QuestHandler.questName + " pt. " + QuestHandler.questPart + ".";
		infoDesc.text = QuestHandler.questDesc;
		menuCanvas.SetActive(true);
	//	mainGroup = GameObject.Find("MainPauseMenu");
	//	loadoutGroup = GameObject.Find("SkillTreesGroup");
		mainGroup.SetActive(true);
		loadoutGroup.SetActive(false);
		isHidden = false;
		dummyButton.interactable = false;
		buttonContinue.interactable = true;
		buttonQuit.interactable = true;
		buttonContinue.Select();
	}
	public void HideMenu()
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
		Pause.pauseOn = false;
		SceneManager.LoadScene("Main_Menu");
	}

	public void ShowShipStatScreen()
	{
		mainGroup.SetActive(false);
		loadoutGroup.SetActive(true);
		GameObject.Find("skilltrees_BGRight").GetComponent<UniversalFillAnim>().CallAnimations(0);
		GameObject.Find("skilltrees_BGLeft").GetComponent<UniversalFillAnim>().CallAnimations(0);
	}

	public void ShowInfoSubmenu()
	{
		GameObject.Find("infosubmenu_BGCentral").GetComponent<UniversalFillAnim>().CallAnimations(0);
	}
}
