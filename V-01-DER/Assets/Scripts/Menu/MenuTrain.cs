using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuTrain : MonoBehaviour 
{
	public TrainController[] trains;
	public int[] delays;

	void Start () {
		
	}
	
	void FixedUpdate () 
	{
		for(int i = 0; i < delays.Length; i++)
		{
			if (delays[i] > 0)
			{
				delays[i]--;
			}
			else if(delays[i] == 0)
			{
				delays[i] = Random.Range(200, 500);
				trains[i].BeginJourney();
			}
		}
	}
}
