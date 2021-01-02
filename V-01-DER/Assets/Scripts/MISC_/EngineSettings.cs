using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineSettings : MonoBehaviour
{

	static public float textSpeed = 0.05f;
	static public int vSyncSetting = 0;
	static public int fpsTarget = 288;
	static public float[] textSizeScalar;
	static public bool bloomEnabled = true;


	void Awake()
	{
		// Value controls vSync
		QualitySettings.vSyncCount = vSyncSetting;
		// Value controls the max FPS
		Application.targetFrameRate = fpsTarget;
	}
}
