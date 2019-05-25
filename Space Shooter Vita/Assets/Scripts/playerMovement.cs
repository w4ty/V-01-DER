using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {

	float maxSpeed = 5f;
	float rotSpeed = 180f;

	void Start () {
		
	}
	
	void Update () {

		// Rotation
		Quaternion rot = transform.rotation;
		float z = rot.eulerAngles.z;
		z -= Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
		rot = Quaternion.Euler(0, 0, z);
		transform.rotation = rot;
		// Vertical movement
		Vector3 pos = transform.position;

		pos.y += Input.GetAxis("Vertical") * maxSpeed * Time.deltaTime;

		transform.position = pos;

	}
}
