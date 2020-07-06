using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundHandler : MonoBehaviour 
{
	public Sprite[] backgrounds;

	public void SetBackground(int bgid)
	{
		this.GetComponent<SpriteRenderer>().sprite = backgrounds[bgid];
	}
}
