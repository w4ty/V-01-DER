using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour 
{
	CircleCollider2D objectCollider;
	SpriteRenderer objectSprite;
	float acc = 0.1f;

	public void OnCall()
	{
		objectCollider = this.GetComponent<CircleCollider2D>();
		objectSprite = this.GetComponent<SpriteRenderer>();
		StartCoroutine(OnExplosion());
	}

	public IEnumerator OnExplosion() 
	{
		for (float scale = 0; scale < 3; scale += acc)
		{
			acc -= 0.0015f;
		//	Debug.LogWarning(scale);
			this.transform.localScale = new Vector3(scale, scale, 0);
			this.objectCollider.radius = scale / 2.4f;
			yield return new WaitForSeconds(0.01f);
		}
		for (float alpha = 1; alpha > 0; alpha -= 0.05f)
		{
		//	Debug.LogWarning("alpha: " + alpha + " / objColor: " + objectSprite.color);
			Color c = objectSprite.color;
			c.a = alpha;
			objectSprite.color = c;
			yield return new WaitForSeconds(0.01f);
		}
		Destroy(gameObject);
		//Debug.Log("Explosive activated");
		yield return new WaitForSeconds(0.1f);
	}
}
