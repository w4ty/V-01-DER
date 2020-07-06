using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
	public bool useSprites;
	public Sprite[] characterPoses = null;
	public Color nameColorEditor;
	static public Color nameColorScript;

	void Start()
	{
		nameColorScript = nameColorEditor;
	}
}
