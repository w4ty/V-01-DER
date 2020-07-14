using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAI : MonoBehaviour {

	public GameObject bullet;

	void Awake () 
	{
		StartCoroutine(AIUpdate());
	}
	
	IEnumerator AIUpdate() 
	{
		while (this != null)
		{
			Debug.Log("Launched AI");
			for (int i = 1; i < 9; i++)
			{
				Debug.Log("DOING LOOP " + transform.position);

				Quaternion rotation = Quaternion.Euler(0, 0, i * 45);
				Vector3 offset = rotation * new Vector3(0, 0.5f, 0);

				GameObject proj = Instantiate(bullet, transform.position + offset, rotation, transform.parent);
				proj.GetComponent<BulletDataHolder>().actStats = GetComponent<ActiveObjectStats>();
			}
			yield return new WaitForSeconds(1/GetComponent<ActiveObjectStats>().objectFirerate);
		}
	}
}
