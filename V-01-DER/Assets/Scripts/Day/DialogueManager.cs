using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

	DialogueParser parser;
	public Button dummyButton;
	public string dialogue, characterName;
	public int lineNum;
	int pose;
	string position;
	string[] options;
	int skip;
	int evidenceAdd;
	int nextEvent;
	public static bool playerTalking;
	public bool buttonClicked;
	List<Button> buttons = new List<Button>();

	public Text dialogueBox;
	public Text nameBox;
	public GameObject choiceBox;

	void OnEnable()
	{
		/*dialogue = "";
		characterName = "";
		pose = 0;
		position = "L";
		playerTalking = false;*/
		parser = GameObject.Find("DialogueParser").GetComponent<DialogueParser>();
		//ShowDialogue();
		//lineNum = 1;
	}
	public void ContDialogue()
	{
		switch (nextEvent)
		{
			case (0):
				Debug.Log("CASE 0");
				EndDialogue();
				break;
			case (1):
				lineNum += skip;
				ShowDialogue(lineNum);

				break;
		}
	}

	public void ButtonPress()
	{
		if (playerTalking == false && InfoMenu.isHidden == true)
		{
			ContDialogue();
		}
	}

	void Update()
	{
		if (playerTalking == true || InfoMenu.isHidden == false)
		{
			dummyButton.interactable = false;
		}
		if (playerTalking == false && InfoMenu.isHidden == true)
		{
			dummyButton.interactable = true;
			dummyButton.Select();
		}
		UpdateUI();
	}
	public void ShowDialogue(int lineNumber)
	{
		Pause.pauseOn = true;
		lineNum = lineNumber;
		ResetImages();
		ParseLine();
	}
	void ResetImages()
	{
		GameObject character = GameObject.Find(characterName);
		if (characterName != "" && character.GetComponent<Character>().useSprites == true)
		{
			Image currSprite = character.GetComponent<Image>();
			currSprite.sprite = null;
			currSprite.enabled = false;
		}
	}
	void ParseLine()
	{
		if (parser.GetName(lineNum) != "Player")
		{
			playerTalking = false;
			characterName = parser.GetName(lineNum);
			dialogue = parser.GetContent(lineNum);
			pose = parser.GetPose(lineNum);
			position = parser.GetPosition(lineNum);
			skip = parser.GetSkip(lineNum);
			evidenceAdd = parser.GetEvidence(lineNum);
			nextEvent = parser.GetNextEvent(lineNum);
			DisplayImages();
		}
		else
		{
			playerTalking = true;
			characterName = "Protagonist";
			//dialogue = "What will you do?";
			pose = 0;
			position = "L";
			skip = 0;
			options = parser.GetOptions(lineNum);
			CreateButtons();
			DisplayImages();
		}
	}
	void DisplayImages()
	{
		GameObject character = GameObject.Find(characterName);
		if (characterName != "" && character.GetComponent<Character>().useSprites == true)
		{
			SetSpritePositions(character);

			Image currSprite = character.GetComponent<Image>();

			currSprite.enabled = true;

			currSprite.sprite = character.GetComponent<Character>().characterPoses[pose];

			nameBox.color = character.GetComponent<Character>().nameColorEditor;
		}
	}
	void SetSpritePositions(GameObject spriteObj)
	{
		if (position == "L")
		{
			spriteObj.transform.position = new Vector2(110, 200);
		}
		else if (position == "R")
		{
			spriteObj.transform.position = new Vector2(1422, 251);
		}

	}
	void CreateButtons()
	{
		for (int i = 0; i < options.Length; i++)
		{
			GameObject button = (GameObject)Instantiate(choiceBox);
			Button b = button.GetComponent<Button>();
			b.Select();
			ChoiceButton cb = button.GetComponent<ChoiceButton>();
			cb.SetText(options[i].Split(':')[0]);
			cb.option = options[i].Split(':')[1];
			cb.box = this;
			b.transform.SetParent(this.transform);
			b.transform.localPosition = new Vector3(0, -25 + (i * 50));
			b.transform.localScale = new Vector3(1, 1, 1);
			buttons.Add(b);
		}
	}
	void UpdateUI()
	{
		if (playerTalking == false)
		{
			ClearButtons();
		}
		dialogueBox.text = dialogue;
		nameBox.text = characterName;
	}
	void ClearButtons()
	{
		for (int i = 0; i < buttons.Count; i++)
		{
			dummyButton.Select();
			Button b = buttons[i];
			buttons.Remove(b);
			Destroy(b.gameObject);
		}
	}
	void EndDialogue()
	{
		Pause.pauseOn = false;
		transform.parent.gameObject.SetActive(false);
	}
}
