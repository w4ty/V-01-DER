using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDMGHandler : MonoBehaviour
{
	public GameObject particles;
	void OnTriggerEnter2D()
	{
		Instantiate(particles, transform.position, transform.rotation);
		//Debug.Log("Bullet triggered");
		Destroy(gameObject);
	}
}
