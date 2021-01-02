using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VirtualButtons : MonoBehaviour
{

	public int currentSelection = 0;
	string[] buttons = new string[4] { "BEGIN", "LOAD GAME", "CREDITS", "CLOSE" };
	public Text text;
	public MenuButtons menuFunctionality;
	public MenuIndicators menuIndicatorLeft;
	public MenuIndicators menuIndicatorRight;
	public SimpleTextAnim outOf;
	SimpleTextAnim textAnim;

	void Awake()
	{
		textAnim = GetComponent<SimpleTextAnim>();
	}

	void Start()
	{
		UpdateSelection();
	}

	void UpdateSelection()
	{
		textAnim.StartTextAnim(buttons[currentSelection], EngineSettings.textSpeed);
		outOf.StartTextAnim(string.Format("{0}/{1}", currentSelection + 1, buttons.Length), EngineSettings.textSpeed);
	}

	void Update()
	{
		if ((Input.GetButtonDown("Left") || Input.GetAxis("Left/Right Dpad") == -1) && currentSelection > 0)
		{
			currentSelection -= 1;
			UpdateSelection();
		}
		else if ((Input.GetButtonDown("Right") || Input.GetAxis("Left/Right Dpad") == 1) && currentSelection < buttons.Length - 1)
		{
			currentSelection += 1;
			UpdateSelection();
		}
		if (Input.GetButtonDown("Submit"))
		{
			ApproveSelection(currentSelection);
		}
		if (currentSelection == 0 && menuIndicatorLeft.state == true)
		{
			menuIndicatorLeft.SwitchStateTo(false);
		}
		else if (currentSelection != 0 && menuIndicatorLeft.state == false)
		{
			menuIndicatorLeft.SwitchStateTo(true);
		}
		if (currentSelection == buttons.Length - 1 && menuIndicatorRight.state == true)
		{
			menuIndicatorRight.SwitchStateTo(false);
		}
		else if (currentSelection != buttons.Length -1 && menuIndicatorRight.state == false)
		{
			menuIndicatorRight.SwitchStateTo(true);
		}
	}

	void ApproveSelection(int sel) 
	{
		switch (sel) 
		{
			case 0:
				{
					menuFunctionality.BeginGame();
					break;
				}
			case 1:
				{
					menuFunctionality.LoadSave();
					break;
				}
			case 2:
				{
					menuFunctionality.ShowCredits();
					break;
				}
			case 3:
				{
					menuFunctionality.CloseGame();
					break;
				}
		}
	}
}
