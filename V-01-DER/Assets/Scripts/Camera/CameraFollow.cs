using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

	public Transform Target;
	public float followSpeed = 5f;
	Vector3 targPos;

	void FixedUpdate ()
	{
		if(Target != null)
		{
			targPos = Target.position;
			targPos.z = transform.position.z;
			transform.position = Vector3.Lerp(transform.position, targPos, Time.deltaTime * followSpeed);
		}
	}
}
