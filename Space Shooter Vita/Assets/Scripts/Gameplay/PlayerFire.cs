using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
	public GameObject bulletPlayerPrefab;
	float cooldownTimer;

	void Update ()
	{
		if (Pause.pauseOn == false)
		{
			cooldownTimer -= Time.deltaTime;

			if (Input.GetButton("Fire1") && cooldownTimer <= 0)
			{
				//Debug.Log("Firing");
				cooldownTimer = this.GetComponent<ActiveObjectStats>().objectAttackDelay;
				Vector3 offset = transform.rotation * new Vector3(0, 0.5f, 0);
				Instantiate(bulletPlayerPrefab, transform.position + offset, transform.rotation);
			}

		}
	}
}
