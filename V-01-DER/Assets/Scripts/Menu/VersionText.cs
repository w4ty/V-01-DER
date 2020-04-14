using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VersionText : MonoBehaviour
{
	void Start()
	{
		this.GetComponent<Text>().text = SetTarget.buildType + " " + SetTarget.versionActual + " " + SetTarget.targetPlatform;
	}
}
