using UnityEngine;
using System.Collections;

public class MovableComponent : MonoBehaviour {
	private GameObject mainCharacter;
	private float currentGravity;
	private Rigidbody2D objectRigidBody;
	private bool boolPushing = false;
	// Use this for initialization
	void Start ()
	{
		mainCharacter = GameObject.Find("Player");
		objectRigidBody = gameObject.GetComponent<Rigidbody2D>();
		objectRigidBody.freezeRotation = true;
	}
	
	// Update is called once per frame
	void Update ()
	{
		applyGravity();
		objectRigidBody = gameObject.GetComponent<Rigidbody2D>();
	}

	public void applyGravity()
	{
		objectRigidBody = gameObject.GetComponent<Rigidbody2D>();

		if (boolPushing == false && GameObject.Find("Player").GetComponent<PlayerMovement>().gamobjPullTarget == null &&
			GameObject.Find("Player").GetComponent<PlayerMovement>().intGravityState > 0)
		{
			objectRigidBody.velocity = new Vector2(0, objectRigidBody.velocity.y);
		}

		currentGravity = mainCharacter.GetComponent<PlayerMovement>().intGravityState;

		float mod = mainCharacter.GetComponent<PlayerMovement>().boolGravityInverted ? -1f : 1f;

		if (currentGravity == 0)
		{
			objectRigidBody.mass = 10f;
			objectRigidBody.gravityScale = 0f * mod;
			objectRigidBody.velocity = new Vector2(objectRigidBody.velocity.x, 0);
		}
		else if(currentGravity == 1)
		{
			objectRigidBody.mass = 10f;
			objectRigidBody.gravityScale = 1f * mod;
		}
		else if(currentGravity == 2)
		{
			objectRigidBody.mass = 20f;
			objectRigidBody.gravityScale = 15f * mod;
		}
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.name == "Player")
		{
			boolPushing = true;
		}
	}

	void OnCollisionExit2D(Collision2D coll)
	{
		if (coll.gameObject.name == "Player")
		{
			boolPushing = false;
		}	
	}
}