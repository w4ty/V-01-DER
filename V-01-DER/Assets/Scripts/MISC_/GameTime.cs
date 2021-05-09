using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTime : MonoBehaviour {

	public static int seconds;
	public static int minutes;
	public static int hours;

	// Use this for initialization
	public void Start () 
	{
		Invoke("Count", 1f);
	}
	
	// Update is called once per frame
	void Count () 
	{
		if (seconds < 59)
		{
			seconds += 1;
		}
		else
		{
			if (minutes < 59)
			{
				minutes += 1;
			}
			else
			{
				hours += 1;
				minutes = 0;
			}
			seconds = 0;
		}
		//Debug.LogError(minutes + "m " + seconds + "s");
		Invoke("Count", 1f);
	}
}
