using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMode : MonoBehaviour
{
	CameraSwitcher camControl;
	PlayerMovementClassic moveClassic;
	PlayerMovementAlt moveNormal;
	SpriteRenderer playerSprite;

	void Start()
	{
		playerSprite = this.GetComponent<SpriteRenderer>();
		moveClassic = this.GetComponent<PlayerMovementClassic>();
		moveNormal = this.GetComponent<PlayerMovementAlt>();
		camControl = GameObject.Find("Cameras").GetComponent<CameraSwitcher>();
		TwinStick();
	}

	public void SideScroller()
	{
		this.transform.position = new Vector3(0, 0, 0);
		this.transform.rotation = Quaternion.Euler(0, 0, 270);
		moveClassic.enabled = true;
		moveNormal.enabled = false;
		CameraSwitcher.cameraReturnTo = 1;
		camControl.ReloadCams();
	}

	public void TwinStick()
	{
		moveClassic.enabled = false;
		moveNormal.enabled = true;
		CameraSwitcher.cameraReturnTo = 0;
		camControl.ReloadCams();
	}

	public void Classic()
	{
		this.transform.position = new Vector3(0, 0, 0);
		this.transform.rotation = Quaternion.Euler(0, 0, 0);
		moveClassic.enabled = true;
		moveNormal.enabled = false;
		CameraSwitcher.cameraReturnTo = 1;
		camControl.ReloadCams();
	}
}
