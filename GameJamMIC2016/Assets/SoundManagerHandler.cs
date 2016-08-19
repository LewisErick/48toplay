using UnityEngine;
using System.Collections;

public class SoundManagerHandler : MonoBehaviour {

	public AudioClip auGravityShift;
	public AudioClip auPull;
	public AudioClip auPause;

	// Use this for initialization
	void Start () {
		if (GameObject.FindGameObjectsWithTag("SoundHandlr").Length > 1)
		{
			Destroy(gameObject);
		}

		DontDestroyOnLoad(gameObject);
	}

	public void playSound(AudioClip au)
	{
		GetComponent<AudioSource>().clip = au;
		GetComponent<AudioSource>().Play();
	}

	public void stopSound()
	{
		GetComponent<AudioSource>().Stop();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
