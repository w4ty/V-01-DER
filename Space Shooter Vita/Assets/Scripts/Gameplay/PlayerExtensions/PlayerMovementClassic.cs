using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovementClassic : MonoBehaviour {

	public float moveSpeed = 10f;
	static public float maxYCoordinate;
	static public float minYCoordinate;
	static public float maxXCoordinate;
	static public float minXCoordinate;
	DashHandler dash;

	private void Start()
	{
		dash = this.GetComponent<DashHandler>();
	}

	void FixedUpdate ()
	{
		if(Pause.pauseOn == false)
		{
			float lh = Input.GetAxis("Horizontal");
			float lv = Input.GetAxis("Vertical");

			// Classic movement
			Vector3 move = new Vector3(lh / moveSpeed, lv / moveSpeed, 0);

			// Dash
			if (Input.GetButton("L1") && dash.canDash == true && Mathf.Abs(lh) + Mathf.Abs(lv) != 0)
			{
				move = new Vector2(lh * 2.5f, lv * 2.5f);
				dash.SetCooldown();
			}

			Vector2 temp = transform.position + move;

			// Check if player can move into the area
			if (temp.y > maxYCoordinate || temp.y < minYCoordinate || temp.x > maxXCoordinate || temp.x < minXCoordinate)
			{
				temp = transform.position;
			}

			transform.position = temp;
		}
	}
}
