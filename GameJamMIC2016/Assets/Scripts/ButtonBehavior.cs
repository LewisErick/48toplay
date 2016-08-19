using UnityEngine;
using System.Collections;

public class ButtonBehavior : MonoBehaviour {

	public bool boolOn = false;
	public bool deactivateBool = false;
	public int deacWait = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		deacActivity();

	}

	void deacActivity()
	{

		if (deactivateBool && deacWait == 0)
		{
			deacWait = 30;
			boolOn = false;
		}

		if (boolOn == false)
		{
			transform.localScale = new Vector3(transform.localScale.x, 0.04089818f, transform.localScale.z);
		}

		if (deacWait > 0)
		{
			boolOn = false;
			if (
				deacWait == 19
				)
			{
				GameObject.Find("Doorlight").GetComponent<DoorlightHandler>().UpdateDoorlight();
				transform.localScale = new Vector3(transform.localScale.x, 0.04089818f, transform.localScale.z);
			}

			if (
				deacWait == 1
				)
			{
				deactivateBool = false;
			}

			deacWait -= 1;
		}
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "Block"
			)
		{
			transform.localScale = new Vector3(transform.localScale.x, 0.02f, transform.localScale.z);
			boolOn = true;
			GameObject.Find("Doorlight").GetComponent<DoorlightHandler>().UpdateDoorlight();
		}
	}

	/*void OnTriggerStay2D(Collider2D coll) {
		if (coll.gameObject.tag == "Block"
			)
		{
			transform.localScale = new Vector3(transform.localScale.x, 0.02f, transform.localScale.z);
			boolOn = true;
		}
	}*/

	void OnTriggerExit2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "Block"
			)
		{
			boolOn = false;
			deactivateBool = true;
		}
	}
}
