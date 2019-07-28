using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowPath : MonoBehaviour
{
	public Text showPathStr;
	// Use this for initialization
	void Start ()
	{
		Debug.Log(SetTarget.saveDataPath);
		showPathStr.text = SetTarget.saveDataPath;
	}
	
}
