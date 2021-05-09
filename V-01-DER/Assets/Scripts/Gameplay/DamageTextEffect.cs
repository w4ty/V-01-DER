using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageTextEffect : MonoBehaviour
{
	Text text;
	float alpha;
	float yPosition;
	// Use this for initialization
	void Start()
	{
		text = GetComponent<Text>();
		StartCoroutine(Animate(10, 0.075f));
	}


	IEnumerator Animate(int dist, float speed)
	{
		float a = 1;
		for (float i = 0; i != dist; i += speed)
		{
			a -= speed/2;
			//Debug.Log(a);
			transform.position = new Vector2(transform.position.x, transform.position.y - speed);
			alpha = a;
			text.color = new Color(text.color.r, text.color.g, text.color.b, alpha);
			//Debug.Log(transform.position);
			yield return new WaitForSeconds(0.016f);
		}
	}
}
