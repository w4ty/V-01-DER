using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest0 : MonoBehaviour
{
	public GameObject player;
	private Quest mainQuest;

	void Start ()
	{
		mainQuest = this.GetComponent<Quest>();
		player.transform.position = new Vector2(-1, 0);
	}
}
