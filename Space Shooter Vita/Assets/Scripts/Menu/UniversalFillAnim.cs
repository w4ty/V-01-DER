using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UniversalFillAnim : MonoBehaviour
{
	public int state;
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

	public IEnumerator InAnim()
	{
		state = 1;
		Debug.Log("Starting InAnim for " + this.name);
		for (float a = 0; a < 1.1f; a += 0.015f)
		{
			this.GetComponent<Image>().fillAmount = a;
			yield return new WaitForSeconds(0.005f);
		}
		Debug.Log("Ending OutAnim for " + this.name);
		state = 0;
		yield return new WaitForSeconds(0.005f);
	}

	public IEnumerator OutAnim()
	{
		state = 1;
		Debug.Log("Starting OutAnim for " + this.name);
		for (float a = 1; a > -0.1f; a -= 0.015f)
		{
			this.GetComponent<Image>().fillAmount = a;
			yield return new WaitForSeconds(0.005f);
		}
		Debug.Log("Ending OutAnim for " + this.name);
		state = 0;
		yield return new WaitForSeconds(0.005f);
	}
}
