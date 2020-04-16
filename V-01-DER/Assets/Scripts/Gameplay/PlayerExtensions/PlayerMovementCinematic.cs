using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementCinematic : MonoBehaviour 
{
	public void PassRot(int rotAngle, int speed)
	{
		StartCoroutine(RotatePlayer(rotAngle, speed));
	}

	public void Start()
	{
		StartCoroutine(RotatePlayer(270, 1));
		StartCoroutine(MoveForward(100, 0.1f));
	}

	public IEnumerator MoveForward(int dist, float speed) 
	{
		for (float i = 0; i < dist; i += speed)
		{
			Debug.Log("DOING: " + i + "/" + dist + " at speed: " + speed);
			Vector2 pos = new Vector2(0, speed);
			transform.position += transform.rotation * pos;
			Debug.Log(transform.position);
			yield return new WaitForSeconds(0.016f);
		}
	}

	public IEnumerator RotatePlayer(int rotAngle, int speed) 
	{
		for (int i = 0; i != rotAngle; i += speed)
		{
			this.transform.rotation = Quaternion.Euler(0, 0, i);
			yield return new WaitForSeconds(0.016f);
		}
	}
}
