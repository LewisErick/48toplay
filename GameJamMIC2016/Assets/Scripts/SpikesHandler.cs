using UnityEngine;
using System.Collections;

public class SpikesHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.name == "Player")
		{
			Application.LoadLevel(Application.loadedLevel);
		}
	}
}
