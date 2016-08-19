using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DoorInputHandler : MonoBehaviour {

	private bool canGo;
	public string nextLevel;
	private int intRotWait = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (
			Input.GetKeyDown(KeyCode.UpArrow) &&
			canGo &&
			GameObject.Find("Doorlight").GetComponent<DoorlightHandler>().boolClear
			)
		{
			Debug.Log(nextLevel);
			SceneManager.LoadScene(nextLevel);
		}
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (GameObject.Find("Player").GetComponent<PlayerMovement>().isOnGround())
		{
			canGo = true;
		}
		else
		{
			canGo = false;	
			intRotWait = 0;
		}
	}

	void OnTriggerStay2D(Collider2D coll) {
		if (GameObject.Find("Player").GetComponent<PlayerMovement>().isOnGround())
		{
			canGo = true;
		}
		else
		{
			canGo = false;
			intRotWait = 0;	
		}
	}

	void OnTriggerExit2D(Collider2D coll) {
		intRotWait = 0;
		canGo = false;
	}
}
