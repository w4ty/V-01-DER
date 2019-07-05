using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDMGHandler : MonoBehaviour
{
	void OnTriggerEnter2D()
	{
		Debug.Log("Bullet triggered");
		Destroy(gameObject);
	}
}
