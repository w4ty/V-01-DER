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
		boc.Open(string.Format("{0}DropTables/drop.ini", SetTarget.worldDataPath));
		tableLength = boc.ReadValue(string.Format("Table{0}", tableId), "Table_Length", 0);
		for (int t = 1; t <= tableLength; t++, slotToFill++)
		{
			if (boc.ReadValue(string.Format("Table{0}", tableId), string.Format("Item{0}_P", t), 0.00f) > Random.Range(0.00f, 100.00f))
			{
				Debug.LogWarning(string.Format("Dropped {0}", boc.ReadValue(string.Format("Table{0}", tableId), string.Format("Item{0}_N", t), "InvalidObject")));
				int amount = Random.Range(boc.ReadValue(string.Format("Table{0}", tableId), string.Format("Item{0}_Amax", t), 1), boc.ReadValue(string.Format("Table{0}", tableId), string.Format("Item{0}_Amin", t), 1));
				Vector3 pos = new Vector3(0, 30 + (slotToFill * -30));
				GameObject button = Instantiate(buttonPrefab, pos, transform.rotation);
				button.transform.SetParent(dropTextGroup.transform, false);
				Button b = button.GetComponent<Button>();
				buttons.Add(b);
				StartCoroutine(CountItem(amount, boc.ReadValue(string.Format("Table{0}", tableId), string.Format("Item{0}_N", t), "InvalidObject"), button.GetComponentInChildren<Text>()));
				//button.GetComponentInChildren<Text>().text = amount + " " + boc.ReadValue("Table" + tableId, "Item" + t + "_N", "InvalidObject");
				//Save to inventory
				inventory.GetComponent<InventoryHandler>().AddToInventory(boc.ReadValue(string.Format("Table{0}", tableId), string.Format("Item{0}_N", t), "InvalidObject"), amount);
			}
			else
			{
				slotToFill--;
				Debug.LogWarning(string.Format("Didn't drop {0}", boc.ReadValue(string.Format("Table{0}", tableId), string.Format("Item{0}_N", t), "InvalidObject")));
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
			xpAmountText.text = string.Format("+{0} exp", i);
			yield return new WaitForSeconds(0.05f);
		}
	}

	IEnumerator CountItem(int maxVal, string name, Text text)
	{
		for (int i = 0; i <= maxVal; i += 5)
		{
			text.text = string.Format("{0} {1}", i, name);
			yield return new WaitForSeconds(0.001f);
		}
		text.text = string.Format("{0} {1}", maxVal, name);
	}
}
