using UnityEngine;
using System.Collections;

public class MovableComponent : MonoBehaviour {
	private GameObject mainCharacter;
	private float currentGravity;
	private Rigidbody2D objectRigidBody;
	// Use this for initialization
	void Start ()
	{
		mainCharacter = GameObject.FindGameObjectWithTag("Main Character");
		objectRigidBody = gameObject.GetComponent<Rigidbody2D>(); 
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void applyGravity()
	{
		currentGravity = mainCharacter.GetComponent<PlayerMovement>().intGravityState;

		if (currentGravity == 0)
		{
			objectRigidBody.gravityScale = 1;
		}
		else if(currentGravity == 1)
		{
			objectRigidBody.gravityScale = 5;
		}
		else if(currentGravity == 2)
		{
			objectRigidBody.gravityScale = 10;
		}

		if(mainCharacter.GetComponent<PlayerMovement>().boolGravityInverted)
		{
			objectRigidBody.gravityScale = -1;
		}
	}
}