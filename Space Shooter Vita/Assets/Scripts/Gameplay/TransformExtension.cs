using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;



public static class TransformExtension
{

	public static void LookAt2D(this Transform transform, Vector3 target)
	{
		var dir = target - transform.position;
		var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	}

}