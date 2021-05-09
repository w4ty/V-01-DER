using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHpBar : MonoBehaviour
{
	[System.NonSerialized] public float Timer;
	[System.NonSerialized] public float Transparency;
	[System.NonSerialized] public Color DefaultColor = new Color(1, 0, 0, 1);
	public Image GhostBar;
	public Text Text;
	public Text Health;
	private Image image;

	private void Start()
	{
		image = GetComponent<Image>();
		Timer = 99;
		Transparency = 0;
		CleanUI();

	}
	public void UpdateHealth(float hp, float maxHp, string name, int level)
	{
		StopCoroutine(IterateColor());
		image.fillAmount = hp / maxHp;
		image.color = DefaultColor;
		Text.text = string.Format("{0} LVL {1}", name, level);
		Health.text = string.Format("{0}/{1}", hp, maxHp);
		Timer = 2;
		Transparency = 1;
	}

	private void FixedUpdate()
	{
		if (Timer > 0 && Timer != 99)
		{
			Timer -= Time.deltaTime;
		}
		else if (image.color == DefaultColor && Timer <= 0)
		{
			StartCoroutine(IterateColor());
		}
		GhostBar.color = new Color(1, 0, 0, Transparency / 2);
		Text.color = new Color(Text.color.r, Text.color.g, Text.color.b, Transparency);
		Health.color = new Color(Health.color.r, Health.color.g, Health.color.b, Transparency);
	}

	public void CleanUI()
	{
		image.color = new Color(1, 0, 0, Transparency);
		GhostBar.color = new Color(1, 0, 0, Transparency / 2);
		Text.color = new Color(Text.color.r, Text.color.g, Text.color.b, Transparency);
		Health.color = new Color(Health.color.r, Health.color.g, Health.color.b, Transparency);
	}

	private IEnumerator IterateColor()
	{
		for (float i = 1; i >= -0.05f; i -= 0.05f)
		{
			image.color = new Color(1, 0, 0, i);
			Transparency = i;
			yield return new WaitForFixedUpdate();
		}
	}
}
