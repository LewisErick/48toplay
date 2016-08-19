using UnityEngine;
using System.Collections;

public class MusicHandler : MonoBehaviour {

	void Awake() {
        DontDestroyOnLoad(gameObject);
	}

	// Use this for initialization
	void Start () {
		if (GameObject.FindGameObjectsWithTag("Background Music").Length > 1) {
			if (GameObject.FindGameObjectsWithTag("Background Music")[0].GetComponent<AudioSource>().clip != GetComponent<AudioSource>().clip)
			{
				GameObject.FindGameObjectsWithTag("Background Music")[0].GetComponent<AudioSource>().clip = GetComponent<AudioSource>().clip;
				GameObject.FindGameObjectsWithTag("Background Music")[0].GetComponent<AudioSource>().Play();
			}
			Destroy(gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
