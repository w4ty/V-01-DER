using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
	public GameObject menuCanvas;
	public GameObject mainCamera;
	public GameObject freeCamera;
	public GameObject explorationCamera;
	public GameObject classicCamera;
	public GameObject playerShip;
	int cooldown;
	static public int cameraReturnTo;
	static public bool screenshotEnabled;

	void Update()
	{
		if (cooldown > 0)
		{
			cooldown--;
		}

		/*if (Input.GetButtonDown("Square") && cooldown <= 0 && screenshotEnabled == false && menuCanvas.activeInHierarchy)
		{
			cooldown = 10;
			EnableSS();
		}
		else if (Input.GetButtonDown("Square") && cooldown <= 0 && screenshotEnabled == true && !menuCanvas.activeInHierarchy)
		{
			cooldown = 10;
			DisableSS();
		}*/
	}

	public void EnableSS()
	{
		menuCanvas.SetActive(false);
		mainCamera.SetActive(false);
		classicCamera.SetActive(false);
		explorationCamera.SetActive(false);
		freeCamera.SetActive(true);
		freeCamera.transform.position = new Vector3(playerShip.transform.position.x, playerShip.transform.position.y, -10);
		screenshotEnabled = true;

	}

	public void DisableSS()
	{
		menuCanvas.SetActive(true);
		ReloadCams();
		freeCamera.SetActive(false);
		screenshotEnabled = false;
	}

	public void ReloadCams()
	{
		switch (cameraReturnTo)
		{
			case (0):
				mainCamera.SetActive(true);
				classicCamera.SetActive(false);
				explorationCamera.SetActive(false);
				break;
			case (1):
				mainCamera.SetActive(false);
				classicCamera.SetActive(true);
				explorationCamera.SetActive(false);
				break;
			case (2):
				mainCamera.SetActive(false);
				classicCamera.SetActive(false);
				explorationCamera.SetActive(true);
				break;
		}
	}
}
