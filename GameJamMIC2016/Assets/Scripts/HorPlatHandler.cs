using UnityEngine;
using System.Collections;

public class HorPlatHandler : MonoBehaviour {

	public int moveHorWait = 100;
	public int side = 1;
	int moveHorWaitRate = 100;

	// Use this for initialization
	void Start () {
		moveHorWaitRate = moveHorWait;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (moveHorWait > 0)
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(3f * side, 0);
			moveHorWait -= 1;
		}
		else
		{
			side = side * -1;
			moveHorWait = moveHorWaitRate;
		}
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.name == "Player")
		{
			coll.gameObject.GetComponent<PlayerMovement>().movX = 3f * side;
		}
	}

	void OnCollisionStay2D(Collision2D coll)
	{
		if (coll.gameObject.name == "Player")
		{
			coll.gameObject.GetComponent<PlayerMovement>().movX = 3f * side;
		}
	}

	void OnCollisionExit2D(Collision2D coll)
	{
		if (coll.gameObject.name == "Player")
		{
			coll.gameObject.GetComponent<PlayerMovement>().movX = 0;
		}	
	}
}
