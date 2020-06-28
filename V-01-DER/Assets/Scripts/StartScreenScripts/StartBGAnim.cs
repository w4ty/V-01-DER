using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBGAnim : MonoBehaviour
{
	public Sprite[] sprites;
	Vector2 setpos = new Vector2(76, 0);
	Vector2 originalpos;
	SpriteRenderer spriteRenderer;
	int lastBgId = -1;
	int currentId;

	void Start()
	{
		setpos = transform.position;
		originalpos = transform.position;
		spriteRenderer = GetComponent<SpriteRenderer>();
		SelectBackdrop();
	}

	void FixedUpdate()
	{
		Debug.Log(transform.position.x);
		setpos.x -= 0.25f;
		transform.position = setpos;
		if (setpos.x < -76f)
		{
			transform.position = originalpos;
			setpos = transform.position;
			SelectBackdrop();
		}
	}

	void SelectBackdrop()
	{
		currentId = Random.Range(0, sprites.Length);
		if (currentId != lastBgId)
		{
			spriteRenderer.sprite = sprites[currentId];
			lastBgId = currentId;
		}
		else
		{
			SelectBackdrop();
		}
	}
}
