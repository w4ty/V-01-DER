using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainController : MonoBehaviour {

	public int type;

	public void BeginJourney () 
	{
		switch (type)
		{
			case 0:
				GetComponent<SpriteRenderer>().flipX = false;
				transform.position = new Vector3(-11, transform.position.y);
				StartCoroutine(MoveForward(22, 0.25f));
				break;
			case 1:
				GetComponent<SpriteRenderer>().flipX = true;
				transform.position = new Vector3(11, transform.position.y);
				StartCoroutine(MoveForward(-22, -0.25f));
				break;
		}
	}

	public IEnumerator MoveForward(int dist, float speed)
	{
		for (float i = 0; i != dist; i += speed)
		{
			Debug.Log("DOING: " + i + "/" + dist + " at speed: " + speed);
			transform.position = new Vector2(transform.position.x + speed, transform.position.y);
			Debug.Log(transform.position);
			yield return new WaitForSeconds(0.016f);
		}
	}
}
