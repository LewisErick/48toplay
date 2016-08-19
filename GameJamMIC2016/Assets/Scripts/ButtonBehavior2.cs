using UnityEngine;
using System.Collections;

public class ButtonBehavior2 : MonoBehaviour {

	public bool boolOn = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.name == "Player"
			)
		{
			boolOn = true;
			transform.localScale = new Vector3(transform.localScale.x, 0.05f, transform.localScale.z);
			GameObject.Find("Doorlight").GetComponent<DoorlightHandler>().UpdateDoorlight();
		}
	}
}
