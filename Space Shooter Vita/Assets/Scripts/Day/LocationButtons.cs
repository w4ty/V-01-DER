using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocationButtons : MonoBehaviour 
{
	public int id;
	public GameObject worldMaster;

	void Start()
	{
		this.GetComponent<Button>().Select();
		//GameObject.Find("WorldMaster");
	}
	public void OnButton()
	{
		Debug.Log("DONE id " + id);
		worldMaster.GetComponent<SwitchHandler>().ParseOption(id, gameObject);
		WorldAction.lockAction = 10;
	}

}
