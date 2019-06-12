using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour {

	public Transform Target;
	public float followSpeed = 5f;
	public float followDistance = 10f;
	Vector3 targPos;

	void Update () {
		if(Target != null)
		{
			targPos = Target.position;
			targPos.z = transform.position.z;
			transform.position = Vector3.Lerp(transform.position, targPos, Time.deltaTime * followSpeed);
		}
	}
}
