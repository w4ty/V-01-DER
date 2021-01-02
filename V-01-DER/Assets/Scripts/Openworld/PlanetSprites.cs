using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSprites : MonoBehaviour 
{
	public Sprite[] voidSprites;

	public Sprite ReturnSprite(int id)
	{
		return voidSprites[id];
	}
}
