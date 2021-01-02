using System.Collections;
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
	public GameObject bar;
	public GameObject overlapEffectImage;
	public GameObject logoObject;
//	public GameObject infoText;
	public GameObject startButton;
	public GameObject loadingIcon;
	public GameObject checkFilesText;
	private Text checkFiles;
	int i;
	float logoSpeed = 0.1f;
	bool readyToMove;

	void Start()
	{
		checkFiles = checkFilesText.GetComponent<Text>();
		startButton.GetComponent<Button>().Select();
		loadingIcon.SetActive(false);
	}

	void Update()
	{
		if (readyToMove == true)
		{
			SceneManager.LoadScene("Main_Menu");
		}
	}

	public void OnButton()
	{
		StartCoroutine(WaitLogo());
		StartCoroutine(MoveLogo());
		startButton.SetActive(false);
		loadingIcon.SetActive(true);
		bar.SetActive(false);
	//	infoText.SetActive(false);
		//infoText.GetComponent<Text>().text = "Welcome to the Void!";
		//DownloadNews();
		StartCoroutine(CheckFiles(SetTarget.universalPath));
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

	public void GoToNext()
	{
		readyToMove = true;
	}

	IEnumerator CheckFiles(string univPath)
	{
		if (Directory.Exists(univPath + "SaveData") == true)
		{
			checkFiles.text += "\n save data folder check success";
		}
		else
		{
			checkFiles.text += "\n save data folder check fail";
		}

		yield return new WaitForSeconds(0.1f);

		if (File.Exists(univPath + "SaveData/savedata_player.ini") == true)
		{
			checkFiles.text += "\n save data file check success";
		}
		else
		{
			checkFiles.text += "\n save data file check fail";
		}

		yield return new WaitForSeconds(1f);
		overlapEffectImage.GetComponent<UniversalFillAnim>().AskToDo(this, "GoToNext");
		overlapEffectImage.GetComponent<UniversalFillAnim>().CallAnimations(0);
	}
}
