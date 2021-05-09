using System.Collections;
using System.Reflection;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UniversalFillAnim : MonoBehaviour
{
	public int state;
	private bool doAfter;
	private Component component;
	private string functionName;

	public void CallAnimations(int b)
	{
		if (b == 0)
		{
			StartCoroutine(InAnim());
		}
		else if (b == 1)
		{
			StartCoroutine(OutAnim());
		}
	}

	public void AskToDo(Component componentToUse, string function)
	{
		//Call before starting an animation
		doAfter = true;
		component = componentToUse;
		functionName = function;
	}

	public IEnumerator InAnim()
	{
		state = 1;
		Debug.Log("Starting InAnim for " + this.name);
		for (float a = 0; a < 1.1f; a += 0.05f)
		{
			this.GetComponent<Image>().fillAmount = a;
			yield return new WaitForFixedUpdate();
		}
		Debug.Log("Ending InAnim for " + this.name);
		state = 0;
		yield return state;
		yield return new WaitForFixedUpdate();
		if (doAfter)
		{
			MethodInfo functionToCall = component.GetType().GetMethod(functionName);
			functionToCall.Invoke(component, null);
		}
		CleanData();
	}

	public IEnumerator OutAnim()
	{
		state = 1;
		Debug.Log("Starting OutAnim for " + this.name);
		for (float a = 1; a > -0.1f; a -= 0.05f)
		{
			this.GetComponent<Image>().fillAmount = a;
			yield return new WaitForFixedUpdate();
		}
		Debug.Log("Ending OutAnim for " + this.name);
		state = 0;
		yield return state;
		yield return new WaitForFixedUpdate();
		if (doAfter)
		{
			MethodInfo functionToCall = component.GetType().GetMethod(functionName);
			functionToCall.Invoke(component, null);
		}
		CleanData();
	}

	public void CleanData()
	{
		doAfter = false;
		component = null;
		functionName = null;
	}
}
