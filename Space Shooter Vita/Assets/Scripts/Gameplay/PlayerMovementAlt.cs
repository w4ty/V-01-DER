using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementAlt : MonoBehaviour {
	public float moveSpeed = 10f;
	public float maxYCoordinate = 10f;
	public float minYCoordinate = -10f;
	public float maxXCoordinate = 10f;
	public float minXCoordinate = -10f;
	void Start () {
		
	}
	
	void Update () {
		// Turn inputs to short floats for easier access
		float lh = Input.GetAxis("Horizontal");
		float lv = Input.GetAxis("Vertical");
		float rh = Input.GetAxis("HorizontalR");
		float rv = Input.GetAxis("VerticalR");
		// Classic movement
		Vector3 Move = new Vector3(lh / moveSpeed, lv / moveSpeed, 0);
		Vector3 temp = transform.position + Move;
		// Movement restriction
		if (temp.y > maxYCoordinate)
		{
			temp.y = maxYCoordinate;
		}
		if (temp.y < minYCoordinate)
		{
			temp.y = minYCoordinate;
		}
		if (temp.x > maxXCoordinate)
		{
			temp.x = maxXCoordinate;
		}
		if (temp.x < minXCoordinate)
		{
			temp.x = minXCoordinate;
		}
		transform.position = temp;
		// Rotation
		Vector3 vNewInput = new Vector3(rh, rv, 0);
		if (vNewInput.sqrMagnitude < 0.05f)
		{
			return;
		}
		var angle = Mathf.Atan2(rh, rv) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0, 0, angle);
	}
}
