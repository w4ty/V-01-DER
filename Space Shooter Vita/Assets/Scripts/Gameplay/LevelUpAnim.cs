using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpAnim : MonoBehaviour 
{
	public GameObject[] detailSprites;
	static string levelUpText = "level up";
	static bool animDone;
	static bool textDone;

	void Update()
	{
		if (animDone == true && textDone == true)
		{
			StartCoroutine(AnimationOut());
		}
	}
	void Start()
	{
		for (int z = 0; z < 2; z++)
		{
			detailSprites[z].GetComponent<Image>().fillAmount = 0;
			this.GetComponentInChildren<Text>().color = new Color(255, 255, 255, 0);
		}
		//Debug.Log("Starting " + this.GetComponentInChildren<Image>().fillAmount);
	}
	public void CallAnims()
	{
		if (animDone == false && textDone == false)
		{
			StartCoroutine(AnimationIn());
			StartCoroutine(TextIn());
		}
	}
	public IEnumerator AnimationIn()
	{
		Debug.Log("Playing anim_in");
			for (float a = 0; a < 1.1f; a += 0.01f)
			{
				for (int z = 0; z < 2; z++)
				{
					detailSprites[z].GetComponent<Image>().fillOrigin = z;
					detailSprites[z].GetComponent<Image>().fillAmount = a;
				}
				yield return new WaitForSeconds(0.01f);
			}
		animDone = true;
	}

	public IEnumerator TextIn()
	{
		this.GetComponentInChildren<Text>().color = new Color(255, 255, 255, 1);
		for (int y = 0; y < levelUpText.Length; y++)
		{
			this.GetComponentInChildren<Text>().text += levelUpText[y];
			yield return new WaitForSeconds(0.3f);
		}
		textDone = true;
	}
	
	public IEnumerator AnimationOut () 
	{
		animDone = false;
		textDone = false;
		for (float a = 1; a > -0.1f; a -= 0.01f)
		{
			this.GetComponentInChildren<Text>().color = new Color(255, 255, 255, a);
			for (int z = 0; z < 2; z++)
			{
				detailSprites[z].GetComponent<Image>().fillOrigin = z + 1;
				detailSprites[z].GetComponent<Image>().fillAmount = a;
			}
			yield return new WaitForSeconds(0.01f);
		}
		this.GetComponentInChildren<Text>().text = "";
	}
}
