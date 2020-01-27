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
	AudioSource audioEngine;

	void Start()
	{
		audioEngine = this.GetComponent<AudioSource>();
	}

	void Update()
	{
		/*if (timer <= 0)
		{
			timerRunning = false;
			readyToPlay = true;
		}*/
		/*if (audioEngine.isPlaying == false && timer <= 0 && readyToPlay == false)
		{
			RandomizeTimer();
		}*/
		if (audioEngine.isPlaying == false && timer > 0 && timerRunning == false && readyToPlay == false)
		{
			StartCoroutine(SubFromTimer());
		}
		if (audioEngine.isPlaying == false && timer <= 0 && readyToPlay == true && timerRunning == false)
		{
			currentSongId = Random.Range(0, songList.Length);
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
		audioEngine.clip = songList[currentSongId];
		audioEngine.Play();
		Debug.Log("Playing: " + audioEngine.clip.name);
		//Debug.LogError(Mathf.RoundToInt(audioEngine.clip.length));
		yield return new WaitForSeconds(Mathf.RoundToInt(audioEngine.clip.length));
		audioEngine.Stop();
		audioEngine.clip = null;
		//Debug.LogError("Ended song and state " + audioEngine.isPlaying + "/" + timer + "/" + readyToPlay + "/" + timerRunning);
		RandomizeTimer();
	}

	void RandomizeTimer()
	{
		timer = Random.Range(1, 10);
		//Debug.Log("Randomized " + timer);
	}
}
