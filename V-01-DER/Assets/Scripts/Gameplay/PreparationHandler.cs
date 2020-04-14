using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PreparationHandler : MonoBehaviour 
{
	public GameObject overlapEffectImage;

	void Start () 
	{
		overlapEffectImage.GetComponent<Image>().fillAmount = 1;
		overlapEffectImage.GetComponent<UniversalFillAnim>().CallAnimations(1);
	}
}
