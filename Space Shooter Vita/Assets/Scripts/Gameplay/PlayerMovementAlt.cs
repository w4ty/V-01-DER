using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovementAlt : MonoBehaviour
{
	[System.NonSerialized] public float moveSpeed = 0.1f;
	static public float maxYCoordinate;
	static public float minYCoordinate;
	static public float maxXCoordinate;
	static public float minXCoordinate;
	public Text xyText;
	DashHandler dash;

	private void Start()
	{
		dash = this.GetComponent<DashHandler>();
	}

	void FixedUpdate()
	{
		//Debug.Log("Layer: " + gameObject.layer + " " + invTimer);
		if (Pause.pauseOn == false)
		{
			// Turn inputs to short floats for easier access
			float lh = Input.GetAxis("Horizontal");
			float lv = Input.GetAxis("Vertical");
			float rh = Input.GetAxis("HorizontalR");
			float rv = Input.GetAxis("VerticalR");
			// Debug input info
			if (Input.GetButton("Submit") && Input.GetButton("Cancel"))
			{
				xyText.text = "lh " + Mathf.Round(lh * 100f) / 100f + " " + "lv " + Mathf.Round(lv * 100f) / 100f + " " + maxXCoordinate + "/" + minXCoordinate + "/" + maxYCoordinate + "/" + minYCoordinate;
			}
			else
			{
				xyText.text = "X: " + Mathf.RoundToInt(this.transform.position.x * 10).ToString() + " / Y: " + Mathf.RoundToInt(this.transform.position.y * 10).ToString();
			}
			// Classic movement
			Vector3 Move = new Vector3(lh * moveSpeed, lv * moveSpeed, 0);
			
			// Dash
			if (Input.GetButton("L1") && dash.canDash == true && Mathf.Abs(lh) + Mathf.Abs(lv) != 0)
			{
				Move = new Vector2(lh * 2.5f, lv * 2.5f);
				dash.SetCooldown();
			}

			Vector2 temp = transform.position + Move;

			// Check if player can move into the area
			if (temp.y > maxYCoordinate || temp.y < minYCoordinate || temp.x > maxXCoordinate || temp.x < minXCoordinate)
			{
				temp = transform.position;
			}

			transform.position = temp;
			// Rotation
			if (SetTarget.controllerName == "ps_generic")
			{
				Vector3 vNewInput = new Vector3(rh, rv, 0);
				if (vNewInput.sqrMagnitude < 0.05f)
				{
					return;
				}
				var angle = Mathf.Atan2(rh, rv) * Mathf.Rad2Deg;
				transform.rotation = Quaternion.Euler(0, 0, angle);
			}
			else if (SetTarget.controllerName == "keyboard")
			{
				Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				float mousePosX = worldPoint.x - transform.position.x;
				float mousePosY = worldPoint.y - transform.position.y;
				float angle = (Mathf.Atan2(mousePosY, mousePosX) * Mathf.Rad2Deg) - 90;
				transform.rotation = Quaternion.Euler(0, 0, angle);
				//Debug.Log("Mouse angle: " + angle + " | Object angle: " + transform.rotation);
			}
		}
	}
}
