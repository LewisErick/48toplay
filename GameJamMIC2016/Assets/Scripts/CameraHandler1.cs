using UnityEngine;
using System.Collections;

public class CameraHandler1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.position = new Vector3(transform.position.x, GameObject.Find("Player").transform.position.y - 1.2f, 
			transform.position.z);
	}
}
