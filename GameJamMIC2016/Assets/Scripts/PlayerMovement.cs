using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float jumpPower = 5f;
	public float movePower = 5f;

	public bool canHit = true;
	public int hitWait = 0;

	//Walk Animations
	public Sprite sWalkLeft;
	public Sprite sWalkRight;
	public RuntimeAnimatorController aWalkLeft;
	public RuntimeAnimatorController aWalkRight;
	
	//Idle Animations
	public Sprite sStandLeft;
	public Sprite sStandRight;
	//public RuntimeAnimatorController aStandLeft;
	//public RuntimeAnimatorController aStandRight;

	//Jump Animations
	public Sprite sJumpLeft;
	public Sprite sJumpRight;
	public RuntimeAnimatorController aJumpLeft;
	public RuntimeAnimatorController aJumpRight;

	Rigidbody2D rig;
	BoxCollider2D boxCollider;
	SpriteRenderer sprite;
	Animator anim;

	public bool boolGravityInverted = true;

	/*
		0 - Zero Gravity
		1 - Normal Gravity
		2 - Heavy Gravity
	*/
	public int intGravityState = 1;

	private bool onGround = false;

	public int life = 100;

	// Use this for initialization
	void Start () {
		life = 3;
		boxCollider = GetComponent<BoxCollider2D>();
		//level = controller.getLevel();
		rig = GetComponent<Rigidbody2D>();
		rig.gravityScale = GetGravity();
		rig.freezeRotation = true;

		//sprite = GetComponent<SpriteRenderer>();
		//anim = GetComponent<Animator>();
	}

	void InvertGravity()
	{
		if (rig.gravityScale > 0)
		{
			boolGravityInverted = true;
			rig.gravityScale = -GetGravity();
		}
		else
		{
			boolGravityInverted = false;
			rig.gravityScale = GetGravity();
		}
	}

	float GetGravity()
	{
		switch (intGravityState)
		{
			case 0:
				movePower = 7;
				jumpPower = 5;
				return 0.3f;
			case 1:
				movePower = 5;
				jumpPower = 7;
				return 1f;
			case 2:
				movePower = 2;
				jumpPower = 5;
				return 10f;
		}
		return 0f;
	}
	
	//FixedUpdate
	void FixedUpdate() {
		rig = GetComponent<Rigidbody2D>();
		/*if (grounded == true && level != 2) {
			if (Input.GetAxis("Horizontal") > 0) {
				sprite.sprite = sWalkRight;
				anim.runtimeAnimatorController = aWalkRight;
			} else {
				if (Input.GetAxis("Horizontal") < 0) {
					sprite.sprite = sWalkLeft;
					anim.runtimeAnimatorController = aWalkLeft;
				} else {
					if (sprite.sprite == sWalkLeft || sprite.sprite == sJumpLeft) {
						sprite.sprite = sStandLeft;
						anim.runtimeAnimatorController = null;
					} else {
						if (sprite.sprite == sWalkRight || sprite.sprite == sJumpRight) {
							sprite.sprite = sStandRight;
							anim.runtimeAnimatorController = null;
						}
					}
				}
			}
		} else {
			if (Input.GetAxis("Horizontal") > 0) {
				sprite.sprite = sJumpRight;
				anim.runtimeAnimatorController = aJumpRight;
			} else {
				if (Input.GetAxis("Horizontal") < 0) {
					sprite.sprite = sJumpLeft;
					anim.runtimeAnimatorController = aJumpLeft;
				} else {
					if (sprite.sprite == sWalkLeft || sprite.sprite == sStandLeft) {
						sprite.sprite = sJumpLeft;
						anim.runtimeAnimatorController = aJumpLeft;
					} else {
						if (sprite.sprite == sWalkRight || sprite.sprite == sStandRight) {
							sprite.sprite = sJumpRight;
							anim.runtimeAnimatorController = aJumpRight;
						}
					}
				}
			}
		}*/
	}

	// Update is called once per frame
	void Update () {
		if (hitWait > 0) {
			hitWait -= 1;
		} else {
			canHit = true;
		}

		if (
			Input.GetKey(KeyCode.LeftArrow)
			)
		{
			rig.velocity = new Vector2(-movePower, rig.velocity.y);
		}
		else if (
			Input.GetKey(KeyCode.RightArrow)
			)
		{
			rig.velocity = new Vector2(movePower, rig.velocity.y);
		}
		else
		{
			rig.velocity = new Vector2(0, rig.velocity.y);
		}

		if (
			Input.GetKeyDown(KeyCode.UpArrow) &&
			onGround
			)
		{
			onGround = false;
			rig.AddForce(new Vector2(0, jumpPower * Mathf.Sign(rig.gravityScale)), ForceMode2D.Impulse);
		}

		if (
			Input.GetKeyDown(KeyCode.Space)
			)
		{
			intGravityState = (intGravityState + 1) % 3;
			rig.gravityScale = GetGravity() * Mathf.Sign(rig.gravityScale);
		}

		if (
			Input.GetKeyDown(KeyCode.Z)
			)
			InvertGravity();
	}
	//Getters and Setters

	

	public void applyDamage(int dmg) {
		canHit = false;
		hitWait = 200;
		life = life - dmg;
		if (life <= 0) {
			//Application.LoadLevel("GameOver");
		}
	}

	void OnCollisionEnter2D(Collision2D coll) {
 		if (
 			coll.gameObject.layer == 8 &&
 			(((Mathf.Sign(rig.gravityScale) > 0) && coll.gameObject.transform.position.y <= transform.position.y) ||
 			((Mathf.Sign(rig.gravityScale) < 0) && coll.gameObject.transform.position.y >= transform.position.y))
 			)
 			onGround = true;
    }

    void OnCollisionExit2D(Collision2D coll) {
    	
    }

    void OnTriggerEnter2D(Collider2D coll) {
    	
    }

    void OnTriggerExit2D(Collider2D coll) {
 		
    }
}