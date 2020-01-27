using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
	public GameObject menuCanvas;
	public GameObject mainCamera;
	public GameObject freeCamera;
	public GameObject playerShip;
	int cooldown;
	static public bool screenshotEnabled;

	void Update()
	{
		if (cooldown > 0)
		{
			cooldown--;
		}

		if (Input.GetButtonDown("Square") && cooldown <= 0 && screenshotEnabled == false && menuCanvas.activeSelf == true)
		{
			cooldown = 10;
			EnableSS();
		}
		else if (Input.GetButtonDown("Square") && cooldown <= 0 && screenshotEnabled == true && menuCanvas.activeSelf == false)
		{
			cooldown = 10;
			DisableSS();
		}
	}

	public void EnableSS()
	{
		menuCanvas.SetActive(false);
		mainCamera.SetActive(false);
		freeCamera.SetActive(true);
		freeCamera.transform.position = new Vector3(playerShip.transform.position.x, playerShip.transform.position.y, -10);
		screenshotEnabled = true;
		
	}

	public void DisableSS()
	{
		menuCanvas.SetActive(true);
		mainCamera.SetActive(true);
		freeCamera.SetActive(false);
		screenshotEnabled = false;
	}
}
