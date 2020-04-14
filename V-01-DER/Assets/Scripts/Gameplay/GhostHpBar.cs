using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GhostHpBar : MonoBehaviour
{
	Image ghostBar;
	public Image hpBar;

	private void Awake()
	{
		ghostBar = this.GetComponent<Image>();
	}

	public void LowerBar()
	{
		StartCoroutine(SubstractFromBar(hpBar.fillAmount));
	}

	IEnumerator SubstractFromBar(float gate)
	{
		while (ghostBar.fillAmount > gate)
		{
			ghostBar.fillAmount -= 0.005f;
			yield return new WaitForSeconds(0.01f);
		}
		yield return new WaitForSeconds(0.1f);
	}
}
