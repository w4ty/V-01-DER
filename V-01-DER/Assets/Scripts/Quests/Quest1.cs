using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest1 : MonoBehaviour
{
	private Quest mainQuest;

	void Start()
	{
		mainQuest = this.GetComponent<Quest>();
	}
}
