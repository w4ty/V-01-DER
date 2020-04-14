using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AccentColor : MonoBehaviour 
{

	public Color accentColor;
	public GameObject[] colorableObjects;
	public Image[] imgComp;

	void Start () 
	{
		imgComp = new Image[colorableObjects.Length];
		for (int i = 0; i < 1; i++)
		{
			Debug.Log(i);
			imgComp[i] = colorableObjects[i].GetComponent<Image>();
		}
	}
	
	void Update () 
	{
		for (int i = 0; i < 1; i++)
		{
			imgComp[i].color = accentColor;
		}
	}
}
