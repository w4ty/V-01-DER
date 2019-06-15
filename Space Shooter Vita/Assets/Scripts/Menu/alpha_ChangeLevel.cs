using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class alpha_ChangeLevel : MonoBehaviour {

	void Update () {
		if (Input.GetButton("Submit"))
		{
			SceneManager.LoadScene("Main");
		}
	}
}
