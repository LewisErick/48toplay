using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public int level;

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

	float oPosX, oPosY; 

	// Use this for initialization
	void Start () {
		life = 3;
		boxCollider = GetComponent<BoxCollider2D>();
		//level = controller.getLevel();
		isAlive = true;
		grounded = false;
		rig = GetComponent<Rigidbody2D>();
		rig.freezeRotation = true;

		sprite = GetComponent<SpriteRenderer>();
		anim = GetComponent<Animator>();

	}
	
	//FixedUpdate
	void FixedUpdate() {
		//Horizontal Movement
		moveX = Input.GetAxis("Horizontal") * movePower * Time.deltaTime;
		if (grounded == true && level != 2) {
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
		}


		Vector3 moveVector = new Vector3(moveX, 0, 0);
		transform.Translate(moveVector);
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
 
    }

    void OnCollisionExit2D(Collision2D coll) {
    	
    }

    void OnTriggerEnter2D(Collider2D coll) {
    	
    }

    void OnTriggerExit2D(Collider2D coll) {
 		
    }
}