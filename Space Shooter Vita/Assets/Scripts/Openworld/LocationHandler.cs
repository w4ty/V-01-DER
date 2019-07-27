using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

public class LocationHandler : MonoBehaviour
{

	static public string locFileToChange;
	public int locationID;
	public Text locationText;
	public Text locationStatus;
	string filePath;
	public int locationType;
	public GameObject blackoutImg;
	public bool onLocation = false;
	static public int selectedLoc;
	static public int locationTypeStatic;
	public GameObject worldMaster;

	void Start()
	{
		worldMaster.GetComponent<OpenworldSet>().OpenWorldStart();
		blackoutImg = GameObject.Find("blackout_img");
	}
	void Update()
	{
		if (Input.GetButtonDown("Submit") && onLocation == true)
		{
			//Blackout();
			selectedLoc = locationID;
			locationTypeStatic = locationType;
			Debug.Log(locationTypeStatic);
			worldMaster.GetComponent<OpenworldSet>().BattleStart();
			//Pause.pauseOn = true;
		}
	}
	void OnTriggerEnter2D()
	{
		// Start ini and load file
		INIParser ini = new INIParser();
		ini.Open(Application.dataPath + "/StreamingAssets/Save/savedata_player.ini");

		onLocation = true;
		// Location IDs and names
		if (locationID == 1)
		{
			locationType = ini.ReadValue("loc_starlessblack", "state", -1);
			locationText.text = "The Starless Black bar";
			Debug.Log(locationType);
		}
		else if (locationID == 2)
		{
			locationType = ini.ReadValue("loc_oldruins", "state", -1);
			locationText.text = "Old ruins";
			Debug.Log(locationType);
		}

		// Location status descriptions
		if (locationType == 0)
		{
			locationStatus.text = "This location is safe to enter.";
		}
		else if (locationType == 1)
		{
			locationStatus.text = "Risk of getting attacked.";
		}
		else if (locationType == 2)
		{
			locationStatus.text = "Risk of getting attacked by a boss.";
		}
		else if (locationType == -1)
		{
			locationStatus.text = "Location cannot be loaded (error value -1).";
		}
	}
	// Clean the text when exiting location
	private void OnTriggerExit2D(Collider2D collision)
	{
		locationText.text = "";
		locationStatus.text = "";
		onLocation = false;
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
