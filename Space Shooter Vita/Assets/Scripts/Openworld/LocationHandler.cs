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
	public int tempLocID;
	public Text locationText;
	public Text locationStatus;
	string filePath;
	public int locationType;
	public GameObject blackoutImg;
	public bool onLocation = false;
	static public int selectedLoc;
	static public int locationTypeStatic;
	public GameObject worldMaster;
	// Start ini and load file
	INIParser ini = new INIParser();


	void Start()
	{
		worldMaster.GetComponent<OpenworldSet>().OpenWorldStart();
		blackoutImg = GameObject.Find("blackout_img");
		ini.Open(SetTarget.saveDataPath);
		tempLocID = 0;
		GetLocation();
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
		tempLocID = locationID;
		GetLocation();
	}
	
	void GetLocation()
	{
		onLocation = true;
		// Location IDs and names
		if (tempLocID == 0)
		{
			locationType = ini.ReadValue("loc_" + tempLocID, "state", -1);
			locationText.text = ini.ReadValue("loc_" + tempLocID, "name", "err");
			Debug.Log(locationType);
		}
		else if (tempLocID == 1)
		{
			locationType = ini.ReadValue("loc_" + tempLocID, "state", -1);
			locationText.text = ini.ReadValue("loc_" + tempLocID, "name", "err");
			Debug.Log(locationType);
		}
		else if (tempLocID == 2)
		{
			locationType = ini.ReadValue("loc_" + tempLocID, "state", -1);
			locationText.text = ini.ReadValue("loc_" + tempLocID, "name", "err");
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
			locationStatus.text = "Location status cannot be loaded (error value -1).";
		}
		else if (locationType == -2)
		{
			locationStatus.text = "";
		}
		Debug.Log(tempLocID + " " + locationID);
	}
	// Clean the text when exiting location
	private void OnTriggerExit2D(Collider2D collision)
	{
		ini.Close();
		locationText.text = "";
		locationStatus.text = "";
		onLocation = false;
		tempLocID = 0;
		GetLocation();
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
