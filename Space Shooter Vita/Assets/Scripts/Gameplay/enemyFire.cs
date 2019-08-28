using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
	public GameObject target;
	public GameObject Bullet_PlayerPrefab;
	public float fireDelay = 0.25f;
	float cooldownTimer = 0.5f;

	void Update()
	{
		if (Pause.pauseOn == false)
		{
			cooldownTimer -= Time.deltaTime;

			if (cooldownTimer <= 0)
			{
				//Debug.Log("Enemy firing");
				cooldownTimer = fireDelay;
				Vector3 offset = transform.rotation * new Vector3(0, 0.5f, 0);
				Instantiate(Bullet_PlayerPrefab, transform.position + offset, transform.rotation);
			}
		}
	}
}
