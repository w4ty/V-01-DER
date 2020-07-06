using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraExplorationMovement : MonoBehaviour 
{
	[System.NonSerialized] public float maxX = 21f;
	[System.NonSerialized] public float minX = 0f;
	Transform playerCursorPos;
	Vector3 pos;

	void Start()
	{
		playerCursorPos = GameObject.Find("Player_Ship_a").transform;
	}

	void FixedUpdate () 
	{
		if (Pause.pauseOn == false)
		{
			if (transform.InverseTransformPoint(playerCursorPos.position).x > 4 && transform.position.x < maxX)
			{
				pos = new Vector2(0.2f, 0);
				Vector2 calc = transform.position + pos;
				transform.position = calc;
			}
			if (transform.InverseTransformPoint(playerCursorPos.position).x < -4 && transform.position.x > minX)
			{
				pos = new Vector2(-0.2f, 0);
				Vector2 calc = transform.position + pos;
				transform.position = calc;
			}
			transform.position = new Vector3(transform.position.x, transform.position.y, -10);
		}
	}
}
