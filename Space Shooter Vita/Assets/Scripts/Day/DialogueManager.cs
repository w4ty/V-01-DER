using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

	DialogueParser parser;
	public Button dummyButton;
	public string dialogue, characterName;
	public int lineNum;
	int pose;
	string position;
	string[] options;
	public bool playerTalking;
	List<Button> buttons = new List<Button>();

	public Text dialogueBox;
	public Text nameBox;
	public GameObject choiceBox;

	void Start () {
		dialogue = "";
		characterName = "";
		pose = 0;
		position = "L";
		playerTalking = false;
		parser = GameObject.Find("DialogueParser").GetComponent<DialogueParser>();
		lineNum = 0;
	}

	void Update()
	{
		if (Input.GetButtonDown("Submit") && playerTalking == false)
		{
			ShowDialogue();

			lineNum++;
		}
		if(playerTalking == true)
		{
			dummyButton.interactable = false;
		}
		else
		{
			dummyButton.interactable = true;
			dummyButton.Select();
		}
		UpdateUI();
	}
	public void ShowDialogue()
	{
		ResetImages();
		ParseLine();
	}
	void ResetImages()
	{
		if (characterName != "")
		{
			GameObject character = GameObject.Find(characterName);
			SpriteRenderer currSprite = character.GetComponent<SpriteRenderer>();
			currSprite.sprite = null;
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
			DisplayImages();
		}
		else
		{
			playerTalking = true;
			characterName = "Player";
			dialogue = "What will you do?";
			pose = 0;
			position = "L";
			options = parser.GetOptions(lineNum);
			CreateButtons();
			DisplayImages();
		}
	}
	void DisplayImages()
	{
		if (characterName != "")
		{
			GameObject character = GameObject.Find(characterName);

			SetSpritePositions(character);

			SpriteRenderer currSprite = character.GetComponent<SpriteRenderer>();

			currSprite.sprite = character.GetComponent<Character>().characterPoses[pose];
		}
	}
	void SetSpritePositions(GameObject spriteObj)
	{
		if (position == "L")
		{
			spriteObj.transform.position = new Vector3(-6, 0, 0);
		}
		else if (position == "R")
		{
			spriteObj.transform.position = new Vector3(6, 0, 0);
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
		if (!playerTalking)
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
			print("Clearing buttons");
			Button b = buttons[i];
			buttons.Remove(b);
			Destroy(b.gameObject);
		}
	}
}
