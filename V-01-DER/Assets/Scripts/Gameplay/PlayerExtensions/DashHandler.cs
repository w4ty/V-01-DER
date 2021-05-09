using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashHandler : MonoBehaviour
{
	public bool canDash;
	public GameObject afterImage;
	private float dashCD;
	private float invTimer;
	private bool invState;
	private GameObject dashObj;
	private Image dashBar;
	private GameObject invObj;
	private Image invBar;

	private void Start()
	{
		dashObj = GameObject.Find("DashBar");
		dashBar = dashObj.GetComponent<Image>();
		invObj = GameObject.Find("InvincibleBar");
		invBar = invObj.GetComponent<Image>();
	}

	void UpdateBar(float fillVal)
	{
		dashBar.fillAmount = fillVal / 3;
	}

	public void SetCooldown()
	{
		dashCD = 3;
		invTimer = 1;
		invState = true;
		InvFrames();
	}

	public void SetAfterImage(Vector2[] positions, Quaternion rotation)
	{
		for (int i = 0; i < positions.Length; i++)
		{

			GameObject temp = Instantiate(afterImage);
			temp.GetComponent<SpriteRenderer>().sprite = GetComponent<SpriteRenderer>().sprite;
			temp.transform.position = positions[i];
			temp.transform.rotation = rotation;
		}
	}

	void FixedUpdate()
	{
		//Debug.Log("Layer: " + gameObject.layer + " " + invTimer);
		if (Pause.pauseOn == false)
		{
			if (dashCD > 0)
			{
				dashCD -= Time.deltaTime;
				UpdateBar(dashCD);
				canDash = false;
			}
			else
			{
				canDash = true;
				UpdateBar(0);
			}
			if (invTimer > 0)
			{
				invTimer -= Time.deltaTime;
				invBar.fillAmount = invTimer;

			}
			else if (invState == true)
			{
				invState = false;
				invTimer = 0;
				InvFrames();
			}
		}
	}

	void InvFrames()
	{
		switch (invState)
		{
			case (true):
				gameObject.layer = 10;
				break;
			case (false):
				gameObject.layer = 8;
				break;
		}
	}

	public void EndCooldown()
	{
		dashCD = 0;
	}
}