using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WelcomeBar : MonoBehaviour
{
	INIParser s = new INIParser();
	Text text;
	int maxChars = 18;

	void Start()
	{
		text = GetComponent<Text>();
		s.Open(SetTarget.universalPath + "welcomebar.ini");
		StartCoroutine(SlideText(s.ReadValue("bartext", "string", "none")));
	}

	IEnumerator SlideText(string original)
	{
		text.text = original.Substring(0, maxChars);
		yield return new WaitForSeconds(2f);
		for (int i = maxChars; i < original.Length + maxChars; i++)
		{
			text.text = text.text.Remove(0, 1);
			try
			{
				text.text += original.Substring(i, 1);
			}
			catch
			{
				text.text += " ";
			}

			yield return new WaitForSeconds(0.25f);
		}
		StartCoroutine(SlideText(original));
	}
}
