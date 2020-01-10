using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{

	public float timer;

	void FixedUpdate ()
	{
		if (Pause.pauseOn == false)
		{
			if (timer <= 0)
			{
				Destroy(gameObject);
			}
			else
			{
				timer--;
			}
		}
	}
}
