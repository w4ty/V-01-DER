using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFree : MonoBehaviour
{
	void FixedUpdate ()
	{
		this.transform.position += new Vector3(Input.GetAxis("Horizontal")/2, Input.GetAxis("Vertical")/2, 0);
	}
}
