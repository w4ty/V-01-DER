using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleRewards : MonoBehaviour
{
	INIParser boc = new INIParser();
	int tableLength;
	int slotToFill;
	public GameObject dropTextGroup;
	public Text xpAmountText;
	public GameObject buttonPrefab;
	public GameObject scrollrect;
	public GameObject scrollbar;
	public GameObject inventory;
	List<Button> buttons = new List<Button>();

	public void DropLoot(int tableId, int expAmount)
	{
		StartCoroutine(CountExp(expAmount));
		boc.Open(SetTarget.worldDataPath + "DropTables/drop.ini");
		tableLength = boc.ReadValue("Table" + tableId, "Table_Length", 0);
		for (int t = 1; t <= tableLength; t++, slotToFill++)
		{
			if (boc.ReadValue("Table" + tableId, "Item" + t + "_P", 0.00f) > Random.Range(0.00f, 100.00f))
			{
				Debug.LogWarning("Dropped " + boc.ReadValue("Table" + tableId, "Item" + t + "_N", "InvalidObject"));
				int amount = Random.Range(boc.ReadValue("Table" + tableId, "Item" + t + "_Amax", 1), boc.ReadValue("Table" + tableId, "Item" + t + "_Amin", 1));
				Vector3 pos = new Vector3(0, 30 + (slotToFill * -30));
				GameObject button = Instantiate(buttonPrefab, pos, transform.rotation);
				button.transform.SetParent(dropTextGroup.transform, false);
				Button b = button.GetComponent<Button>();
				buttons.Add(b);
				StartCoroutine(CountItem(amount, boc.ReadValue("Table" + tableId, "Item" + t + "_N", "InvalidObject"), button.GetComponentInChildren<Text>()));
				//button.GetComponentInChildren<Text>().text = amount + " " + boc.ReadValue("Table" + tableId, "Item" + t + "_N", "InvalidObject");
				//Save to inventory
				inventory.GetComponent<InventoryHandler>().AddToInventory(boc.ReadValue("Table" + tableId, "Item" + t + "_N", "InvalidObject"), amount);
			}
			else
			{
				slotToFill--;
				Debug.LogWarning("Didn't drop " + boc.ReadValue("Table" + tableId, "Item" + t + "_N", "InvalidObject"));
			}
		}
		scrollrect.GetComponent<ScrollRect>().content = dropTextGroup.GetComponent<RectTransform>();
		scrollbar.GetComponent<Scrollbar>().value = 1;
		slotToFill = 0;
	}
	public void DestroyButtons()
	{
		for (int i = 0; i < buttons.Count; i++)
		{
			//	Debug.Log("COUNT : " + i + " / " + buttons.Count);
			//	Debug.LogError("OBJECT " + i + " " + buttons[i]);
			Destroy(buttons[i].gameObject);
		}
		buttons.Clear();
	}

	IEnumerator CountExp(int maxVal)
	{
		for (int i = 0; i <= maxVal; i++)
		{
			xpAmountText.text = "+" + i + " exp";
			yield return new WaitForSeconds(0.05f);
		}
	}

	IEnumerator CountItem(int maxVal, string name, Text text)
	{
		for (int i = 0; i <= maxVal; i += 5)
		{
			text.text = i + " " + name;
			yield return new WaitForSeconds(0.001f);
		}
		text.text = maxVal + " " + name;
	}
}
