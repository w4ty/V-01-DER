using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineSettings : MonoBehaviour
{
	void Update()
	{
		// Value controls vSync
		QualitySettings.vSyncCount = 1;
		// Value controls the max FPS
		Application.targetFrameRate = 60;
	}
}
