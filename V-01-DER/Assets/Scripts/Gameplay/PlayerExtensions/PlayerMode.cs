using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMode : MonoBehaviour
{
	CameraSwitcher camControl;
	PlayerMovementClassic moveClassic;
	PlayerMovementAlt moveNormal;
	PlayerMovementCinematic moveCinematic;
	GameObject crosshair;
	SpriteRenderer playerSprite;
	public Sprite[] sprites;

	void Start()
	{
		crosshair = transform.GetChild(0).gameObject;
		playerSprite = GetComponent<SpriteRenderer>();
		moveClassic = GetComponent<PlayerMovementClassic>();
		moveNormal = GetComponent<PlayerMovementAlt>();
		moveCinematic = GetComponent<PlayerMovementCinematic>();
		camControl = GameObject.Find("Cameras").GetComponent<CameraSwitcher>();
		TwinStick();
	}

/*	private void Update()
	{
		Debug.Log("SPRITE: " + playerSprite.sprite);
	}*/

	public void Exploration(float xMin, float xMax)
	{
		playerSprite.gameObject.SetActive(true);
		crosshair.SetActive(false);
		this.transform.position = new Vector3(0, 0, 0);
		this.transform.rotation = Quaternion.Euler(0, 0, 0);
		moveClassic.enabled = true;
		moveNormal.enabled = false;
		moveCinematic.enabled = false;
		moveClassic.dashEnabled = false;
		PlayerMovementClassic.maxXCoordinate = xMax + 10f;
		PlayerMovementClassic.minXCoordinate = xMin - 10f;
		CameraSwitcher.cameraReturnTo = 2;
		camControl.ReloadCams();
		playerSprite.sprite = sprites[2];
		this.GetComponent<PlayerFire>().enabled = false;
	}

	public void Cinematic()
	{
		playerSprite.gameObject.SetActive(true);
		crosshair.SetActive(false);
		moveClassic.enabled = false;
		moveNormal.enabled = false;
		moveCinematic.enabled = true;
		CameraSwitcher.cameraReturnTo = 1;
		camControl.ReloadCams();
		playerSprite.sprite = sprites[0];
	}

	public void SideScroller()
	{
		playerSprite.gameObject.SetActive(true);
		crosshair.SetActive(false);
		this.transform.position = new Vector3(0, 0, 0);
		this.transform.rotation = Quaternion.Euler(0, 0, 270);
		moveClassic.enabled = true;
		moveNormal.enabled = false;
		moveCinematic.enabled = false;
		CameraSwitcher.cameraReturnTo = 1;
		camControl.ReloadCams();
		playerSprite.sprite = sprites[1];
		Debug.Log("sprite: " + playerSprite.sprite + " array: " + sprites[1] + " " + sprites[0] + " this " + this.gameObject);
	}

	public void TwinStick()
	{
		playerSprite.gameObject.SetActive(true);
		crosshair.SetActive(true);
		moveClassic.enabled = false;
		moveNormal.enabled = true;
		moveCinematic.enabled = false;
		CameraSwitcher.cameraReturnTo = 0;
		camControl.ReloadCams();
		playerSprite.sprite = sprites[0];
	}

	public void Classic()
	{
		playerSprite.gameObject.SetActive(true);
		crosshair.SetActive(false);
		this.transform.position = new Vector3(0, 0, 0);
		this.transform.rotation = Quaternion.Euler(0, 0, 0);
		moveClassic.enabled = true;
		moveNormal.enabled = false;
		moveCinematic.enabled = false;
		CameraSwitcher.cameraReturnTo = 1;
		camControl.ReloadCams();
		playerSprite.sprite = sprites[0];
	}
}
