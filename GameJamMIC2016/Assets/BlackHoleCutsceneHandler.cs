using UnityEngine;
using System.Collections;

public class BlackHoleCutsceneHandler : MonoBehaviour {

	public bool act = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (act == true)
		{
			transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y),
				new Vector2(GameObject.Find("Ship").transform.position.x, GameObject.Find("Ship").transform.position.y), 0.05f);	
			transform.localScale = new Vector3(transform.localScale.x * 1.02f, transform.localScale.y * 1.02f, transform.localScale.z);
		}
	}
}
