using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float jumpPower = 2.5f;
	public float movePower = 2f;

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

	public int intGravityState = 0;

	private bool onGround = false;

	public int life = 100;

	// Use this for initialization
	void Start () {
		life = 3;
		boxCollider = GetComponent<BoxCollider2D>();
		//level = controller.getLevel();
		rig = GetComponent<Rigidbody2D>();
		rig.freezeRotation = true;

		//sprite = GetComponent<SpriteRenderer>();
		//anim = GetComponent<Animator>();
	}
	
	//FixedUpdate
	void FixedUpdate() {
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
			rig.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
		}

		if (
			Input.GetKeyDown(KeyCode.Space)
			)
		{
			intGravityState = (intGravityState + 1) % 3;
		}
	}

	// Update is called once per frame
	void Update () {
		if (hitWait > 0) {
			hitWait -= 1;
		} else {
			canHit = true;
		}
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
 			coll.gameObject.transform.position.y <= transform.position.y
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