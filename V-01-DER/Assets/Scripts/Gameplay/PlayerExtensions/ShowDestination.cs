using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowDestination : MonoBehaviour 
{
	SpriteRenderer sprite;
	bool navigating;
	Quaternion desiredRotation;
	Vector2 dir;
	float zAngle;
	Transform temporaryTransform;
	Vector3 objective;
	[System.NonSerialized] public float x = 6;
	[System.NonSerialized] public float y = 4;

	void Start () 
	{
		SetDestination();
		sprite = GetComponent<SpriteRenderer>();
	}

	public void SetDestination()
	{
		objective = new Vector3(x, y);
		navigating = true;
	}

	public void ResetDestination()
	{
		objective = new Vector3(0, 0);
		navigating = false;
	}

	void Update() 
	{
		if ((transform.position.x > x + 2.5f || transform.position.x < x - 2.5f || transform.position.y > y + 2.5f || transform.position.y < y - 2.5f) && navigating)
		{
			sprite.enabled = true;
			dir = transform.position - objective;
			dir.Normalize();
			float zAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + 90;
			desiredRotation = Quaternion.Euler(0, 0, zAngle);
			transform.rotation = desiredRotation;
			//Debug.Log("Desired destination: " + objective + " our current: " + transform.position + " desired rotation: " + desiredRotation + " current rotation: " + transform.rotation);
		}
		else
		{
			sprite.enabled = false;
			navigating = false;
		}
	}
}
