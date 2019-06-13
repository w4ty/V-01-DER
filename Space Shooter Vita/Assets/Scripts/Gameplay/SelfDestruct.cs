using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour {

	float timer = 0;

	void Update () {
		timer += 1;

		if(timer >= 260)
		{
			Destroy(gameObject);
		}
	}
}
