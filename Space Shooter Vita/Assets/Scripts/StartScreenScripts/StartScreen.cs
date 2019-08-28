﻿using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using System.Security.Cryptography.X509Certificates;
using System;
using System.IO;

public class StartScreen : MonoBehaviour
{
	GameObject logoObject;
	GameObject infoText;
	GameObject startButton;
	GameObject loadingIcon;
	GameObject checkFilesText;
	int i;
	float logoSpeed = 0.1f;
	bool wasDone;
	bool readyToMove;

	void Start()
	{
		logoObject = GameObject.Find("LOGO");
		infoText = GameObject.Find("InfoText");
		startButton = GameObject.Find("CrossButton");
		loadingIcon = GameObject.Find("LoadingIcon");
		checkFilesText = GameObject.Find("FileCheckText");
		loadingIcon.SetActive(false);
	}

	void Update()
	{
		if (Input.GetButton("Cross") && wasDone == false)
		{
			wasDone = true;
			StartCoroutine(WaitLogo());
			StartCoroutine(MoveLogo());
			startButton.SetActive(false);
			loadingIcon.SetActive(true);
			infoText.GetComponent<Text>().text = "Welcome to the Void!";
			//DownloadNews();
			StartCoroutine(CheckFiles(SetTarget.universalPath));
		}
		if (readyToMove == true)
		{
			SceneManager.LoadScene("Main_Menu");
		}
	}

	IEnumerator MoveLogo()
	{
		while (i < 35)
		{
			logoObject.transform.position = new Vector3(logoObject.transform.position.x, logoObject.transform.position.y + logoSpeed, logoObject.transform.position.z);
			yield return new WaitForSeconds(0.001f);
			i++;
			logoSpeed -= 0.0025f;
		}
	}
	void HideLogo()
	{
		logoObject.GetComponent<SpriteRenderer>().enabled = false;
	}

	void ShowLogo()
	{
		logoObject.GetComponent<SpriteRenderer>().enabled = true;
	}
	IEnumerator WaitLogo()
	{
		HideLogo();
		yield return new WaitForSeconds(0.1f);
		ShowLogo();
	}

	void DownloadNews()
	{
		string newsUrl = "https://www.dropbox.com/s/x82tm7q3k1tll59/v01d_news.ini?dl=1"/*"https://drive.google.com/uc?export=download&id=1JAB0v2oapcdrnNLc3df4ViQ4wJCLatTb"*/;
		using (var wc = new WebClient())
		{
			Uri downUri = new Uri(newsUrl, UriKind.Absolute);
			wc.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/46.0.2490.33 Safari/537.36");
			ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
			wc.DownloadFileAsync(downUri, SetTarget.webDataPath + "V1.ini");
			readyToMove = true;
		}
	}
	IEnumerator GoToNextDelayed()
	{
		yield return new WaitForSeconds(2f);
		readyToMove = true;
	}

	IEnumerator CheckFiles(string univPath)
	{
		if (Directory.Exists(univPath + "SaveData") == true)
		{
			checkFilesText.GetComponent<Text>().text = checkFilesText.GetComponent<Text>().text + "\n save data folder check success";
		}
		else
		{
			checkFilesText.GetComponent<Text>().text = checkFilesText.GetComponent<Text>().text + "\n save data folder check fail";
		}

		yield return new WaitForSeconds(0.1f);

		if (File.Exists(univPath + "SaveData/savedata_player.ini") == true)
		{
			checkFilesText.GetComponent<Text>().text = checkFilesText.GetComponent<Text>().text + "\n save data file check success";
		}
		else
		{
			checkFilesText.GetComponent<Text>().text = checkFilesText.GetComponent<Text>().text + "\n save data file check fail";
		}

		yield return new WaitForSeconds(0.1f);

		StartCoroutine(GoToNextDelayed());
	}
}