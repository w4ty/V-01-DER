using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowFPS : MonoBehaviour
{
	float deltaTime = 0.0f;

	void Update()
	{
		deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
		float msec = deltaTime * 1000.0f;
		float fps = 1.0f / deltaTime;
		this.GetComponent<Text>().text = Mathf.RoundToInt(fps).ToString() + "/" + (msec).ToString().Substring(0, 5) + "ms";
	}

	/*void OnGUI()
	{
		int w = Screen.width, h = Screen.height;

		GUIStyle style = new GUIStyle();

		Rect rect = new Rect(0, 0, w, h * 2 / 100);
		style.alignment = TextAnchor.MiddleLeft;
		style.fontSize = h * 4 / 100;
		style.normal.textColor = new Color(1f, 1f, 1f, 1.0f);
		
		string text = string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);
		GUI.Label(rect, text, style);
	}*/
}
