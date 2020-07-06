using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExploreSet : MonoBehaviour 
{
	public PlayerMode playerModeSet;
	public GameObject visualsGroup;
	public Text locText;
	public BackgroundHandler backgroundHandler;
	public GameObject dialogueObject;
	public DialogueManager dialogueManager;
	public DialogueParser dialogueParser;
	public GameObject[] locationObjects;
	INIParser ini = new INIParser();

	public void SetLocation (int bgid) 
	{
		visualsGroup.SetActive(true);
		visualsGroup.transform.GetChild(0).gameObject.GetComponent<UniversalFillAnim>().InAnim();
		backgroundHandler.SetBackground(bgid);
		locationObjects[bgid].SetActive(true);
		ini.Open(SetTarget.worldDataPath + "Worlds/" + LocationHandler.worldName + "/Planets/locations.ini");
		playerModeSet.Exploration(ini.ReadValue("id" + bgid, "x_min", 0), ini.ReadValue("id" + bgid, "x_max", 0));
		locText.text += string.Format(" - {0}", ini.ReadValue(("id" + bgid), "name", "err"));
	}
	
	public void StartDialogue(int id, int lineBegin) 
	{
		dialogueObject.SetActive(true);
		dialogueParser.LoadFile(SetTarget.dialDataPath + SetTarget.lang + "/Objects/object_id_" + id + ".txt", lineBegin);
		//dialogueManager.ShowDialogue(lineBegin);
	}
}
