using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBeh : MonoBehaviour 
{
	bool exploded;
	DamageHandler objDamageHandler;
	public GameObject explosionObj;
	GameObject tempExplosion;

	void Start()
	{
		objDamageHandler = this.GetComponent<DamageHandler>();
	}

	void Update()
	{
		if(objDamageHandler.hp <= 0 && exploded == false)
		{
			Explode();
		}
	}
	
	void Explode () 
	{
		exploded = true;
		tempExplosion = Instantiate(explosionObj);
		tempExplosion.transform.position = this.transform.position;
		tempExplosion.GetComponent<Explosion>().OnCall();
	}
}
