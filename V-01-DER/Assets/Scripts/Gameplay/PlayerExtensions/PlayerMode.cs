using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMode : MonoBehaviour
{
	CameraSwitcher camControl;
	PlayerMovementClassic moveClassic;
	PlayerMovementAlt moveNormal;
	PlayerMovementCinematic moveCinematic;
	SpriteRenderer playerSprite;
	public Sprite[] sprites;

	void Start()
	{
		playerSprite = this.gameObject.GetComponent<SpriteRenderer>();
		moveClassic = this.GetComponent<PlayerMovementClassic>();
		moveNormal = this.GetComponent<PlayerMovementAlt>();
		moveCinematic = this.GetComponent<PlayerMovementCinematic>();
		camControl = GameObject.Find("Cameras").GetComponent<CameraSwitcher>();
		TwinStick();
	}

/*	private void Update()
	{
		Debug.Log("SPRITE: " + playerSprite.sprite);
	}*/

	public void Cinematic()
	{
		moveClassic.enabled = false;
		moveNormal.enabled = false;
		moveCinematic.enabled = true;
		CameraSwitcher.cameraReturnTo = 1;
		camControl.ReloadCams();
		playerSprite.sprite = sprites[0];
	}

	public void SideScroller()
	{
		this.transform.position = new Vector3(0, 0, 0);
		this.transform.rotation = Quaternion.Euler(0, 0, 270);
		moveClassic.enabled = true;
		moveNormal.enabled = false;
		CameraSwitcher.cameraReturnTo = 1;
		camControl.ReloadCams();
		playerSprite.sprite = sprites[1];
		Debug.Log("sprite: " + playerSprite.sprite + " array: " + sprites[1] + " " + sprites[0] + " this " + this.gameObject);
	}

	public void TwinStick()
	{
		moveClassic.enabled = false;
		moveNormal.enabled = true;
		CameraSwitcher.cameraReturnTo = 0;
		camControl.ReloadCams();
		playerSprite.sprite = sprites[0];
	}

	public void Classic()
	{
		this.transform.position = new Vector3(0, 0, 0);
		this.transform.rotation = Quaternion.Euler(0, 0, 0);
		moveClassic.enabled = true;
		moveNormal.enabled = false;
		CameraSwitcher.cameraReturnTo = 1;
		camControl.ReloadCams();
		playerSprite.sprite = sprites[0];
	}
}
