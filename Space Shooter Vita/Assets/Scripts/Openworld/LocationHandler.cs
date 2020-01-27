using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

public class LocationHandler : MonoBehaviour
{

	static public string worldName = "MAINVOID";
	static public string locFileToChange;
	public int locationID;
	int tempLocID;
	public Text locationText;
	public Text locationStatus;
	string filePath;
	static public int selectedLoc;
	public int locationType;
	static public int locationControl;
	static public int locationTypeStatic;
	public GameObject worldMaster;
	// Start ini and load file
	INIParser planetSaveData = new INIParser();
	INIParser planetActualData = new INIParser();


	void Start()
	{
		planetSaveData.Open(SetTarget.saveDataPath + "planetdata.ini");
		planetActualData.Open(SetTarget.worldDataPath + "Worlds/" + worldName + "/Planets/planets.ini");
		tempLocID = 0;
		GetLocation();
	}

	private void OnTriggerEnter2D()
	{
		tempLocID = locationID;
		WorldAction.selectedLocID = tempLocID;
		GetLocation();
		WorldAction.onLocation = true;
	}

	void GetLocation()
	{
		locationType = planetActualData.ReadValue("Planet" + tempLocID, "type", -1);
		locationText.text = planetActualData.ReadValue("Planet" + tempLocID, "name", "err");
		if (planetSaveData.ReadValue("Planet" + tempLocID, "planetctrl", -1) >= 0)
		{
			locationStatus.text = "Location control: " + planetSaveData.ReadValue("Planet" + tempLocID, "planetctrl", -1) + "%";
		}
		else
		{
			locationStatus.text = "";
		}
	}

	// Clean the text when exiting location
	private void OnTriggerExit2D(Collider2D collision)
	{
		planetSaveData.Close();
		locationText.text = "";
		locationStatus.text = "";
		WorldAction.onLocation = false;
		tempLocID = 0;
		GetLocation();
	}
}
