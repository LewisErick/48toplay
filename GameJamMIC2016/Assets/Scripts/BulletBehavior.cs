using UnityEngine;
using System.Collections;

public class BulletBehavior : MonoBehaviour {

	float targetX, targetY, moveX, moveY;	
	private float speed;
	Vector2 chaseVector;

	public void changeSpeed(float sp) {
		speed = sp;
	}

	public void initializeBullet(float x, float y) {
		targetX = x;
		targetY = y;
		speed = 0.025f;

		chaseVector = new Vector2(0,0);
		moveX = 0f;
		moveY = 0f;
		if (x > transform.position.x) {
			moveX = towards(transform.position.x, speed, x);
		}
		else { 
			if (x < transform.position.x) {
				moveX = towards(transform.position.x, -speed, x);
			}
		}
		if (y > transform.position.y) {
			moveY = towards(transform.position.y, speed, y);
		}
		else { 
			if (y < transform.position.y) {
				moveY = towards(transform.position.y, -speed, y);
			}
		}
		chaseVector = new Vector2(moveX, moveY);
	}

	public void chase(float x, float y) {
		chaseVector = new Vector2(0,0);
		moveX = 0f;
		moveY = 0f;
		if (x > transform.position.x) {
			moveX = towards(transform.position.x, speed, x);
		}
		else { 
			if (x < transform.position.x) {
				moveX = towards(transform.position.x, -speed, x);
			}
		}
		if (y > transform.position.y) {
			moveY = towards(transform.position.y, speed, y);
		}
		else { 
			if (y < transform.position.y) {
				moveY = towards(transform.position.y, -speed, y);
			}
		}
		chaseVector = new Vector2(moveX, moveY);
		Debug.Log(speed);
		transform.Translate(chaseVector);
	}

	public float towards(float x, float deltaX, float targetX) {
		if (Mathf.Abs((targetX - x)) - Mathf.Abs(deltaX) < 0) {
			deltaX = targetX - x;
		}
		return deltaX;
	}

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void FixedUpdate () {
		chase(targetX, targetY);
	}
}