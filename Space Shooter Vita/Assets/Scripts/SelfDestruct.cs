using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour {

	float timer = 120f;

	void Update () {
		timer -= 1f;

		if(timer <= 0)
		{
			Destroy(gameObject);
		}
	}
}
