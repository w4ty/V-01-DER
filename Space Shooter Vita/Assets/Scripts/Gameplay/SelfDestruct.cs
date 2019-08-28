using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{

	public float timer = 0;

	void Update ()
	{
		if (Pause.pauseOn == false)
		{
			timer -= 1;

			if (timer <= 0)
			{
				Destroy(gameObject);
			}
		}
	}
}
