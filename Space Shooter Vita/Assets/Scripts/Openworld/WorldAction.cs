using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldAction : MonoBehaviour
{
	static public int lockAction;
	int optionID;
	static public int selectedLocID;
	static public string worldName;
	public GameObject buttonPrefb;
	public GameObject buttonCanvas;
	public GameObject bgImage;
	UniversalFillAnim bgFill;
	List<Button> buttons = new List<Button>();
	static public int buttonAmount;
	static public bool onLocation;


	// Blackout related
	public GameObject blackoutImg;


	// INI controllers
	INIParser pAD = new INIParser();


	void Start()
	{
		bgFill = bgImage.GetComponent<UniversalFillAnim>();
		this.GetComponent<OpenworldSet>().OpenWorldStart();
		blackoutImg = GameObject.Find("blackout_img");
		pAD.Open(SetTarget.worldDataPath + "Worlds/" + worldName + "/Planets/planets.ini");
	}

	void FixedUpdate()
	{
		if (lockAction > 0)
		{
			lockAction--;
		}
	}

	void Update()
	{
		if (Input.GetButtonUp("Submit") && onLocation == true && Pause.pauseOn == false && lockAction == 0)
		{
			buttonCanvas.SetActive(true);
			bgFill.CallAnimations(0);
			onLocation = false;
			buttonAmount = pAD.ReadValue("Planet" + selectedLocID, "buttons_amount", -1);
			Debug.Log(selectedLocID + " counted " + buttonAmount + " buttons " + pAD.ReadValue("Planet" + selectedLocID, "buttons_amount", -1));
			CreateButtons();
			Pause.pauseOn = true;
			buttonPrefb.GetComponent<Button>().Select();
			SwitchHandler.locID = selectedLocID;
			/*Blackout();
			selectedLoc = locationID;
			locationTypeStatic = locationType;
			Debug.Log(locationTypeStatic);
			worldMaster.GetComponent<OpenworldSet>().BattleStart();
			Pause.pauseOn = true;*/
		}
	}

	public void CreateButtons()
	{
		for (int i = 0; i < buttonAmount; i++)
		{
			GameObject button = (GameObject)Instantiate(buttonPrefb);
			Button b = button.GetComponent<Button>();
			b.Select();
			b.transform.SetParent(buttonCanvas.transform);
			b.transform.localPosition = new Vector3(416, 0 + (i * -32));
			b.transform.localScale = new Vector3(1, 1, 1);
			buttons.Add(b);
		//	Debug.LogWarning("BUTTONS: " + buttons.Count);
			b.GetComponent<LocationButtons>().id = i + 1;
			optionID = pAD.ReadValue("Planet" + selectedLocID, "button" + (i + 1), -1);
			Debug.Log("Planet" + selectedLocID + "button" + (i + 1));
			Debug.Log("OptionID " + optionID);
			b.GetComponentInChildren<Text>().text = pAD.ReadValue("ButtonID" + optionID, "text", "err");
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
		//Debug.LogError("START");
		for (int i = 0; i < buttons.Count; i++)
		{
		//	Debug.Log("COUNT : " + i + " / " + buttons.Count);
		//	Debug.LogError("OBJECT " + i + " " + buttons[i]);
			Destroy(buttons[i].gameObject);
		}
		Pause.pauseOn = false;
		buttons.Clear();
		//Debug.LogError("END");
	}

	void Blackout()
	{
		StartCoroutine(FadeImage(true));
	}
	IEnumerator FadeImage(bool fadeAway)
	{
		Debug.Log("void Blackout");
		for (float i = 0; i <= 1; i += 0.01f)
		{
			blackoutImg.GetComponent<RawImage>().color = new Color(0, 0, 0, i);
			yield return null;
		}
	}
}
