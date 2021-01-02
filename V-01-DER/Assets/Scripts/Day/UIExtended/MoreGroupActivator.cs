using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class MoreGroupActivator : MonoBehaviour 
{
	public GameObject[] groups;

	public void ActivateGroup(int groupId)
	{
		try
		{
			for (int i = 0; i < groups.Length; i++)
			{
				groups[i].SetActive(false);
			}
			groups[groupId].SetActive(true);
		}
		catch
		{
			Debug.LogError(string.Format("Group of id {0} not implemented!\nImplement the group or remove the call from the object calling it.", groupId));
		}
	}
}
