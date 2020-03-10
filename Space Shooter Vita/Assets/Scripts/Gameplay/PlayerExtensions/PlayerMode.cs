using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMode : MonoBehaviour
{

	PlayerMovementClassic moveClassic;
	PlayerMovementAlt moveNormal;
	SpriteRenderer playerSprite;

	void Start()
	{
		playerSprite = this.GetComponent<SpriteRenderer>();
		moveClassic = this.GetComponent<PlayerMovementClassic>();
		moveNormal = this.GetComponent<PlayerMovementAlt>();
	}

	public void SideScroller()
	{
		moveClassic.enabled = true;
		moveNormal.enabled = false;
	}

	public void TwinStick()
	{
		moveClassic.enabled = false;
		moveNormal.enabled = true;
	}

	public void Classic()
	{
		moveClassic.enabled = true;
		moveNormal.enabled = false;
	}
}
