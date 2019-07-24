using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

public class LocationHandler : MonoBehaviour {

	static public string locFileToChange;
	public int locationID;
	public Text locationText;
	public Text locationStatus;
	string filePath;
	public int locationType;
	public GameObject blackoutImg;
	public bool onLocation = false;
	static public int selectedLoc;
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
			Blackout();
			selectedLoc = locationID;
			worldMaster.GetComponent<OpenworldSet>().BattleStart();
			//Pause.pauseOn = true;
		}
	}
	void OnTriggerEnter2D()
	{
		onLocation = true;
		// Location IDs and names
		if (locationID == 1)
		{
			filePath = Application.dataPath + "/StreamingAssets/Save/loc_starlessblack";
			StreamReader r = new StreamReader(filePath);
			locationType = int.Parse(r.ReadLine());
			locationText.text = "The Starless Black bar";
		}
		else if (locationID == 2)
		{
			filePath = Application.dataPath + "/StreamingAssets/Save/loc_oldruins";
			StreamReader r = new StreamReader(filePath);
			locationType = int.Parse(r.ReadLine());
			locationText.text = "Old ruins";
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
