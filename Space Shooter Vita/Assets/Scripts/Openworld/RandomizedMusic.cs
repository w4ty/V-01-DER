using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizedMusic : MonoBehaviour
{
	int timer = 3;
	int lastSongId = -1;
	int currentSongId;
	bool timerRunning;
	bool readyToPlay;
	public AudioClip[] songList;

	void Update()
	{
		/*if (timer <= 0)
		{
			timerRunning = false;
			readyToPlay = true;
		}*/
		/*if (this.GetComponent<AudioSource>().isPlaying == false && timer <= 0 && readyToPlay == false)
		{
			RandomizeTimer();
		}*/
		if (this.GetComponent<AudioSource>().isPlaying == false && timer > 0 && timerRunning == false && readyToPlay == false)
		{
			StartCoroutine(SubFromTimer());
		}
		if (this.GetComponent<AudioSource>().isPlaying == false && timer <= 0 && readyToPlay == true && timerRunning == false)
		{
			currentSongId = Random.Range(0, 3);
		//	Debug.LogWarning("Selected: " + currentSongId);
			if (currentSongId != lastSongId)
			{
				StartCoroutine(PlaySelected());
			//	Debug.LogWarning("Playing: " + currentSongId);
			}
		}
	}

	IEnumerator SubFromTimer()
	{
		/*if (timer <= 0)
		{
			timerRunning = false;
			readyToPlay = true;
		}*/
		while (timer > 0)
		{
			timerRunning = true;
			timer -= 1;
		//	Debug.Log(timer);
			yield return new WaitForSeconds(1f);
		}
	//	Debug.LogWarning("END TIMER");
		timerRunning = false;
		readyToPlay = true;
	//	Debug.LogWarning(readyToPlay);
		yield return new WaitForSeconds(0.1f);
	}

	IEnumerator PlaySelected()
	{
		readyToPlay = false;
		lastSongId = currentSongId;
		this.GetComponent<AudioSource>().clip = songList[currentSongId];
		this.GetComponent<AudioSource>().Play();
		//Debug.LogError(Mathf.RoundToInt(this.GetComponent<AudioSource>().clip.length));
		yield return new WaitForSeconds(Mathf.RoundToInt(this.GetComponent<AudioSource>().clip.length));
		this.GetComponent<AudioSource>().Stop();
		this.GetComponent<AudioSource>().clip = null;
		//Debug.LogError("Ended song and state " + this.GetComponent<AudioSource>().isPlaying + "/" + timer + "/" + readyToPlay + "/" + timerRunning);
		RandomizeTimer();
	}

	void RandomizeTimer()
	{
		timer = Random.Range(1, 10);
		//Debug.Log("Randomized " + timer);
	}
}
