using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovementAlt : MonoBehaviour
{
	[System.NonSerialized] public float MoveSpeed = 0.1f;
	[System.NonSerialized] public Vector2[] Positions = new Vector2[5];
	public static float MaxYCoordinate;
	public static float MinYCoordinate;
	public static float MaxXCoordinate;
	public static float MinXCoordinate;
	public Quaternion RotationAfter;
	public Text XyText;
	private float positionMultiplier;
	private DashHandler dash;


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
				XyText.text = "lh " + (lh * 100f) / 100f + " " + "lv " + (lv * 100f) / 100f + " " + MaxXCoordinate + "/" + MinXCoordinate + "/" + MaxYCoordinate + "/" + MinYCoordinate;
			}
			else
			{
				XyText.text = "X: " + (this.transform.position.x * 10).ToString() + " / Y: " + (this.transform.position.y * 10).ToString();
			}
			// Classic movement
			Vector3 Move = new Vector3(lh * MoveSpeed, lv * MoveSpeed, 0);
			
			// Dash
			if (Input.GetButton("L1") && dash.canDash == true && Mathf.Abs(lh) + Mathf.Abs(lv) != 0)
			{
				Move = new Vector2(lh * 2.5f, lv * 2.5f);
				RotationAfter = transform.rotation;
				positionMultiplier = 0.5f;
				dash.SetCooldown();
				for (int i = 0; i < 5; i++)
				{
					Positions[i] = new Vector2(transform.position.x + Move.x * positionMultiplier, transform.position.y + Move.y * positionMultiplier);
					positionMultiplier += 0.1f;
				}
				dash.SetAfterImage(Positions, RotationAfter);
			}

			Vector2 temp = transform.position + Move;

			// Check if player can move into the area
			if (temp.y > MaxYCoordinate || temp.y < MinYCoordinate || temp.x > MaxXCoordinate || temp.x < MinXCoordinate)
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
