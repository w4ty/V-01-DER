using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
	private DamageHandler damageHandlerComp;


	void Start()
	{
		damageHandlerComp = this.GetComponent<DamageHandler>();
	}
	void Update () 
	{
		if (damageHandlerComp.Hp <= 0)
		{
			//damageHandlerComp.kill();
		}
	}
}
