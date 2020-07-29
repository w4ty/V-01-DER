using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExploreSet : MonoBehaviour 
{
	public PlayerMode playerModeSet;
	public GameObject visualsGroup;
	public Text locText;
	public GameObject buttonPrefb;
	public GameObject buttonCanvas;
	public UniversalFillAnim bgFill;
	int optionID;
	List<Button> buttons = new List<Button>();
	public BackgroundHandler backgroundHandler;
	public GameObject dialogueObject;
	public DialogueManager dialogueManager;
	public DialogueParser dialogueParser;
	public GameObject[] locationObjects;
	INIParser ini = new INIParser();
	int id;

	void Update()
	{
		if (Input.GetButtonUp("Square") && !Pause.pauseOn)
		{
			Pause.pauseOn = true;
			SubLocMenu();
		}
	}

	public void SetLocation(int bgid)
	{
		id = bgid;
		visualsGroup.SetActive(true);
		visualsGroup.transform.GetChild(0).gameObject.GetComponent<UniversalFillAnim>().InAnim();
		backgroundHandler.SetBackground(id + 1);
		locationObjects[id].SetActive(true);
		ini.Open(SetTarget.worldDataPath + "Worlds/" + LocationHandler.worldName + "/Planets/locations.ini");
		playerModeSet.Exploration(ini.ReadValue("id" + id, "x_min", 0), ini.ReadValue("id" + id, "x_max", 0));
		locText.text += string.Format(" - {0}", ini.ReadValue(("id" + bgid), "name", "err"));
	}

	public void SubLocMenu()
	{
		for (int i = 0; i < ini.ReadValue("id" + id, "buttons_amount", 0); i++)
		{
			GameObject button = (GameObject)Instantiate(buttonPrefb);
			Button b = button.GetComponent<Button>();
			b.Select();
			buttonCanvas.SetActive(true);
			b.transform.SetParent(buttonCanvas.transform);
			b.transform.localPosition = new Vector3(-386, 0 + (i * -32));
			b.transform.localScale = new Vector3(1, 1, 1);
			b.GetComponent<LocationButtons>().file = "locations";
			b.GetComponent<LocationButtons>().group = "id";
			buttons.Add(b);
			b.GetComponent<LocationButtons>().id = i + 1;
			optionID = ini.ReadValue("id" + id, "button" + (i + 1), -1);
			b.GetComponentInChildren<Text>().text = ini.ReadValue("ButtonID" + optionID, "text", "err");
		}
	}

	public void DoOutAnim()
	{
		bgFill.AskToDo(this, "DestroyButtons");
		bgFill.CallAnimations(1);
	}

	public void DestroyButtons()
	{
		buttonCanvas.SetActive(false);
		for (int i = 0; i < buttons.Count; i++)
		{
			Destroy(buttons[i].gameObject);
		}
		Pause.pauseOn = false;
		buttons.Clear();
	}

	public void EndLocation()
	{
		backgroundHandler.SetBackground(0);
		visualsGroup.SetActive(false);
		ini.Close();
		playerModeSet.TwinStick();
	}
	
	public void StartDialogue(int id, int lineBegin) 
	{
		dialogueObject.SetActive(true);
		dialogueParser.LoadFile(SetTarget.dialDataPath + SetTarget.lang + "/Objects/object_id_" + id + ".txt", lineBegin);
		//dialogueManager.ShowDialogue(lineBegin);
	}
}
