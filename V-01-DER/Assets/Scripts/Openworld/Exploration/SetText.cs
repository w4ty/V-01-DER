using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class SetText : MonoBehaviour
{
	private Text text;

	private void Awake()
	{
		text = GetComponent<Text>();
	}

	public void SetName(string name)
	{
		text.text = name;
	}

	public void ClearText()
	{
		text.text = "";
	}
}
