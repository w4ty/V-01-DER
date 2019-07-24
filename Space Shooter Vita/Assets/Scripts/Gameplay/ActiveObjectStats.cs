using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveObjectStats : MonoBehaviour
{
	static public int damageOnCol;
	public int damageGetEditor;

	void Start()
	{
		damageOnCol = damageGetEditor;
	}
}
