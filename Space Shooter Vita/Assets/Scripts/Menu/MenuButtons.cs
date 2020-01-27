using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButtons : MonoBehaviour
{
	public GameObject overlapEffectImage;
	private UniversalFillAnim fillAnim;

	void Start()
	{
		fillAnim = overlapEffectImage.GetComponent<UniversalFillAnim>();
		overlapEffectImage.GetComponent<Image>().fillAmount = 1;
		fillAnim.CallAnimations(1);
	}
	public void BeginGame()
	{
		fillAnim.CallAnimations(0);
		StartCoroutine(GoGameplayNew());
	}
	public IEnumerator GoGameplayNew()
	{
		if (fillAnim.state == 1)
		{
			yield return new WaitForSeconds(0.2f);
			StartCoroutine("GoGameplayNew");
		}
		else
		{
			SceneManager.LoadScene("Gameplay_Battle");
			QuestHandler.Prologue();
		}
	}
	public void LoadSave()
	{
		this.GetComponent<LoadGame>().LoadPlayerStats();
		this.GetComponent<LoadGame>().LoadPlayerInfo();
		this.GetComponent<LoadGame>().QueueLoad();
		SceneManager.LoadScene("Gameplay_Battle");
	}
	public void OpenOptions()
	{
		Debug.Log("Options not yet implemented.");
	}
	public void ShowCredits()
	{
		Debug.Log("Credits not yet implemented.");
	}
}
