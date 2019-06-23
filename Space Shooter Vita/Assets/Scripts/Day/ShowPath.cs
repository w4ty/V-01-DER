using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPath : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log(Application.dataPath + "/StreamingAssets");
	}
	
}
