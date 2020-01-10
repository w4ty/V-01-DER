using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillSwitch : MonoBehaviour
{
	DamageHandler currentToKill;
	static public bool kill;

	void Start()
	{
		currentToKill = this.GetComponent<DamageHandler>();
	}

	void Update()
	{
		if (kill == true)
		{
			currentToKill.CleanUp();
		}
		kill = false;
	}

}
