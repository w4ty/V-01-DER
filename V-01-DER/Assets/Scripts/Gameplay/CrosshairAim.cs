using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairAim : MonoBehaviour
{
	private GameObject crosshair;
	private Transform crossTransform;
	// Use this for initialization
	void Awake()
	{
		crosshair = gameObject;
		crossTransform = GameObject.FindGameObjectWithTag("Player").transform.GetChild(0);
	}

	void FixedUpdate()
	{
		crossTransform.LookAt2D(crosshair.transform.position);
		crosshair.transform.rotation = GameObject.Find("Player_Ship_a").transform.rotation;
	}

}
