using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuIndicators : MonoBehaviour
{
	Text text;
	public bool state = true;

	void Start()
	{
		text = GetComponent<Text>();
	}

	public void SwitchStateTo(bool switchTo)
	{
		text.enabled = switchTo;
		state = switchTo;
	}
}
