using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
	public GameObject target;
	public GameObject bullet_PlayerPrefab;
	float fireRate;
	float cooldown;

	void Start()
	{
		fireRate = GetComponent<ActiveObjectStats>().ObjectFirerate;
	}

	void FixedUpdate()
	{
		if (Pause.pauseOn == false)
		{
			if (cooldown < 1)
			{
				cooldown += fireRate / 50;
			}

			if (cooldown >= 1)
			{
				cooldown -= 1;
				//Debug.Log("Enemy firing");
				fireRate = GetComponent<ActiveObjectStats>().ObjectFirerate;
				Vector3 offset = transform.rotation * new Vector3(0, 0.5f, 0);
				GameObject bullet = Instantiate(bullet_PlayerPrefab, transform.position + offset, transform.rotation, transform.parent);
				bullet.GetComponent<BulletDataHolder>().actStats = GetComponent<ActiveObjectStats>();
			}
		}
	}
}
