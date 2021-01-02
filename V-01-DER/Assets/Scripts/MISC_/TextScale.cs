using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextScale : MonoBehaviour 
{
	public int textType;

	void OnEnable()
	{
		try
		{
			GetComponent<Text>().fontSize *= (int)EngineSettings.textSizeScalar[textType];
		}
		catch
		{
			Debug.LogError("Object " + gameObject.name + " does not contain a Text component, or the font scaling failed for unknown reason.");
		}
	}
}
