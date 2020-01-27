using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryHandler : MonoBehaviour
{

	INIParser kc = new INIParser();

	public void AddToInventory(string itemName, int amount)
	{
		kc.Open(SetTarget.saveDataPath + "inventorydata.ini");
		kc.WriteValue(itemName, "amount", amount + kc.ReadValue(itemName, "amount", amount));
		kc.Close();
	}

	public void SubstractFromInventory(string itemName, int amount)
	{
		kc.Open(SetTarget.saveDataPath + "inventorydata.ini");
		kc.WriteValue(itemName, "amount", kc.ReadValue(itemName, "amount", 0) - amount);
		kc.Close();
	}

	public void ChangePropertiesInInventory(string itemName, string property, int amount)
	{
		kc.Open(SetTarget.saveDataPath + "inventorydata.ini");
		kc.WriteValue(itemName, "amount", amount + kc.ReadValue(itemName, "amount", amount));
		kc.Close();
	}
}
