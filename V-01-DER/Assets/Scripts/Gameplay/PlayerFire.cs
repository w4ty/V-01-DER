using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
	public GameObject bulletPlayerPrefab;
	public ParticleSystem particles;
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

			if (Input.GetButton("Fire1") && cooldown >= 1)
			{
				particles.Play();
				cooldown -= 1;
				fireRate = GetComponent<ActiveObjectStats>().ObjectFirerate;
				Vector3 offset = transform.rotation * new Vector3(0, 0.5f, 0);
				GameObject bullet = Instantiate(bulletPlayerPrefab, transform.position + offset, transform.rotation);
				bullet.GetComponent<BulletDataHolder>().actStats = GetComponent<ActiveObjectStats>();
			}
		}
	}
}
