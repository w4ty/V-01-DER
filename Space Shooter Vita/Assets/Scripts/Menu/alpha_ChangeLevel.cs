using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class alpha_ChangeLevel : MonoBehaviour {

	void Update () {
		if (Input.GetButton("Cross"))
		{
			SceneManager.LoadScene("Gameplay_Battle");
		}
		else if (Input.GetButton("Circle"))
		{
			SceneManager.LoadScene("Gameplay_Other");
		}
	}
}
