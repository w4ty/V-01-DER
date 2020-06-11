using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterimageAnimation : MonoBehaviour
{

	SpriteRenderer sprite;

	void Awake()
	{
		sprite = GetComponent<SpriteRenderer>();
		StartCoroutine(Disappear());
	}

	IEnumerator Disappear()
	{
		for (float i = 1; i >= -0.1f; i -= 0.1f)
		{
			sprite.color = new Color(1f, 1f, 1f, i);
			yield return new WaitForSeconds(0.025f);
		}
	}
}
