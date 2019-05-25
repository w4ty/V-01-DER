using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {

	public float maxSpeed = 7f;
	public float rotSpeed = 270f;
	public float maxYCoordinate = 10f;
	public float minYCoordinate = -10f;
	void Start () {
		
	}
	
	void Update () {

		// Rotation
		Quaternion rot = transform.rotation;
		float z = rot.eulerAngles.z;
		z -= Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
		rot = Quaternion.Euler(0, 0, z);
		transform.rotation = rot;
		// Movement
		Vector3 pos = transform.position;

		Vector3 velocity = new Vector3(0, Input.GetAxis("Vertical") * maxSpeed * Time.deltaTime, 0);

		pos += rot * velocity;

		// Movement restriction
		if (pos.y > maxYCoordinate)
		{
			pos.y = maxYCoordinate;
		}
		if (pos.y < minYCoordinate)
		{
			pos.y = minYCoordinate;
		}
		transform.position = pos;
	}
}
