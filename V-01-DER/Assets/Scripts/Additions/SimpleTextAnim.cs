using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleTextAnim : MonoBehaviour
{
	// Only set one as true.
	/* Explanation: OnlyAcceptDirectCalls tells the object to only do animation on a direct call (OnEnable isn't counted as a direct call),
	 while AcceptOnEnable will make the object do the animation everytime it's enabled (it can still be called through a direct call). */

	public bool OnlyAcceptDirectCalls;
	public bool AcceptOnEnable;
	Text currentText;
	string startingText;

	void Awake()
	{
		// Set in Awake because OnEnable runs before Start causing an exception (even though it still works).

		currentText = GetComponent<Text>();
		startingText = currentText.text;
	}

	void Start()
	{
		if (OnlyAcceptDirectCalls == false && AcceptOnEnable == false)
		{
			StartCoroutine(DoText(currentText.text, EngineSettings.textSpeed));
		}
		else if (OnlyAcceptDirectCalls == true && AcceptOnEnable == true)
		{
			Debug.LogWarning("WARNING: OnlyAcceptDirectCalls and AcceptOnEnable should never both be true! DoText won't run.\nCheck text object for incorrect setup: " + gameObject.name + "\nExplanation: OnlyAcceptDirectCalls tells the object to only do animation on a direct call (OnEnable isn't counted as a direct call), while AcceptOnEnable will make the object do the animation everytime it's enabled (it can still be called through a direct call).");
		}
	}

	void OnEnable()
	{
		if (OnlyAcceptDirectCalls == false && AcceptOnEnable == true)
		{
			StartCoroutine(DoText(currentText.text, EngineSettings.textSpeed));
		}
	}

	void OnDisable()
	{
		if (OnlyAcceptDirectCalls == false && AcceptOnEnable == true)
		{
			currentText.text = startingText;
		}
	}

	public void StartTextAnim(string original, float speed)
	{
		StartCoroutine(DoText(original, speed));
	}

	IEnumerator DoText(string original, float speed)
	{
		currentText.text = "";
		for (int i = 0; i < original.Length; i++)
		{
			currentText.text += original.Substring(i, 1);
			yield return new WaitForSeconds(speed);
		}
	}
}
