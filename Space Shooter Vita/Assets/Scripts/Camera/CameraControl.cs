using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraControl : MonoBehaviour
{
	float cameraSize;
	float maxCameraSize = 12f;
	float minCameraSize = 3.1f;
	int cooldown;
	float zoomAlpha;
	public GameObject zoomBack;
	public GameObject zoomUI;
	public GameObject zoomText;
	public GameObject zoomIcon;

	void Awake()
	{
		cameraSize = this.GetComponent<Camera>().orthographicSize;
	}
	void FixedUpdate()
	{
		if ((Input.GetAxis("Left/Right Dpad") < 0 || Input.GetButton("Right")) && cameraSize < maxCameraSize)
		{
			cameraSize += 0.10f;
			SizeChange();
			this.GetComponent<Camera>().orthographicSize = cameraSize;
		}
		if ((Input.GetAxis("Left/Right Dpad") > 0 || Input.GetButton("Left")) && cameraSize > minCameraSize)
		{
			cameraSize -= 0.10f;
			SizeChange();
			this.GetComponent<Camera>().orthographicSize = cameraSize;
		}
		if (Input.GetAxis("Up/Down Dpad") > 0 || Input.GetButtonDown("Down"))
		{
			cameraSize = 6.0f;
			SizeChange();
			this.GetComponent<Camera>().orthographicSize = cameraSize;
		}
		if (cooldown > 0)
		{
			cooldown -= 1;
		}
		if (cooldown <= 0)
		{
			zoomAlpha -= 0.1f;
			ChangeAlpha();
		}
	}
	void SizeChange()
	{
		zoomText.GetComponent<Text>().text = string.Format("{0:#.0}x", ((cameraSize) / 6.0f));
		Debug.Log(cameraSize);
		cooldown = 3;
		zoomUI.SetActive(true);
		zoomAlpha = 1f;
		ChangeAlpha();

	}
	void ChangeAlpha()
	{
		zoomText.GetComponent<Text>().color = new Color(255, 255, 255, zoomAlpha);
		zoomBack.GetComponent<RawImage>().color = new Color(255, 255, 255, zoomAlpha);
		zoomIcon.GetComponent<RawImage>().color = new Color(255, 255, 255, zoomAlpha);
	}
}
