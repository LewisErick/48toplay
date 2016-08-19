using UnityEngine;
using System.Collections;

public class SoundDirectorHandler : MonoBehaviour {

	public AudioClip sndStatic;
	public AudioClip sndText;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SoundStatic()
	{
		GetComponent<AudioSource>().Play();
		GetComponent<AudioSource>().loop = true;
	}

	public void Stop()
	{
		GetComponent<AudioSource>().Stop();
	}
}
