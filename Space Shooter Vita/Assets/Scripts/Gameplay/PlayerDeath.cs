using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour 
{
	void Update () 
	{
		if (this.GetComponent<DamageHandler>().hp <= 0)
		{
			Debug.Log("PlayerDeath");
		}
	}
}
