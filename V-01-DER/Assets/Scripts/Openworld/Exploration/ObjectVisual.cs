using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectVisual : MonoBehaviour
{
	public int id;
	public int lineStart;
	public string title;
	public SetText textHandler;
	public ExploreSet exploreSet;
	public int[] options;
	bool isColliding;

	void OnTriggerEnter2D()
	{
		textHandler.SetName(title);
		isColliding = true;
	}

	void Update()
	{
		if (Input.GetButtonDown("Submit") && isColliding && Pause.pauseOn == false)
		{
			exploreSet.StartDialogue(id, lineStart);
			isColliding = false;
		}
	}

	void OnTriggerExit2D()
	{
		textHandler.ClearText();
		isColliding = false;
	}
}
