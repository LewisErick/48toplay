using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour {

	public float jumpPower = 5f;
	public float movePower = 5f;

	public bool canHit = true;
	public int hitWait = 0;

	//Walk Animations

	public Sprite sWalkRight;
	public RuntimeAnimatorController aWalkRight;
	
	//Idle Animations
	
	public Sprite sStandRight;
	//public RuntimeAnimatorController aStandLeft;
	//public RuntimeAnimatorController aStandRight;

	//Jump Animations
	
	public Sprite sJumpRight;
	public RuntimeAnimatorController aJumpRight;

	public Sprite sPushRight;
	public RuntimeAnimatorController aPushRight;

	public Sprite sPullRight;
	public RuntimeAnimatorController aPullRight;	

	public GameObject gamobjPullTarget;

	Rigidbody2D rig;
	BoxCollider2D boxCollider;
	SpriteRenderer sprite;
	Animator anim;

	List<Material> arrmattBoxMaterials;

	public bool boolGravityInverted = false;

	bool boolCouldPush = false;
	bool boolPushing = false;

	/*
		0 - Zero Gravity
		1 - Normal Gravity
		2 - Heavy Gravity
	*/
	public int intGravityState = 0;

	private bool onGround = false;

	public int life = 100;

	public float movX = 0f;

	// Use this for initialization
	void Start () {
		arrmattBoxMaterials = new List<Material>();
		GetMaterials();

		life = 3;
		boxCollider = GetComponent<BoxCollider2D>();
		//level = controller.getLevel();
		rig = GetComponent<Rigidbody2D>();
		rig.gravityScale = GetGravity();
		rig.freezeRotation = true;

		sprite = GetComponent<SpriteRenderer>();
		anim = GetComponent<Animator>();
	}

	public void GetMaterials()
	{
		GameObject[] arrgamobjBlockModels = GameObject.FindGameObjectsWithTag("BlockModel");
		foreach (GameObject gamobjBlockModel in arrgamobjBlockModels)
		{
			foreach(Material matt in gamobjBlockModel.GetComponent<MeshRenderer>().materials)
	 		{
	     		if(matt.name == "13 - Brushed Metal (Instance)" || matt.name == "13 - Brushed Metal")
	     		{
	     			arrmattBoxMaterials.Add(matt);
	     		}
	 		}
		}
	}

	void InvertGravity()
	{
		if (rig.gravityScale > 0)
		{
			sprite.flipY = true;
			boolGravityInverted = true;
			rig.gravityScale = -GetGravity();
		}
		else
		{
			sprite.flipY = false;
			boolGravityInverted = false;
			rig.gravityScale = GetGravity();
		}
	}

	float GetGravity()
	{
		switch (intGravityState)
		{
			case 0:
				foreach (Material mattBoxMaterial in arrmattBoxMaterials)
				{
			 		mattBoxMaterial.SetColor("_Color", new Color(0f, 0f, 200f, 1f));
				}

				movePower = 7;
				jumpPower = 3;
				return 0.3f;
			case 1:
				foreach (Material mattBoxMaterial in arrmattBoxMaterials)
				{
					mattBoxMaterial.SetColor("_Color", new Color(200f, 200f, 0f, 1f));
				}

				movePower = 5;
				jumpPower = 5;
				return 1f;
			case 2:
				foreach (Material mattBoxMaterial in arrmattBoxMaterials)
				{
					mattBoxMaterial.SetColor("_Color", new Color(200f, 0f, 0f, 1f));
				}

				movePower = 2;
				jumpPower = 5;
				return 10f;
		}
		return 0f;
	}
	
	//FixedUpdate
	void FixedUpdate() {
		/*
		rig = GetComponent<Rigidbody2D>();
		if (onGround) {
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

		float modPullHor = gamobjPullTarget != null ? 0.25f : 1f;

		if (
			Input.GetKey(KeyCode.LeftArrow)
			)
		{
			if (
				gamobjPullTarget != null
				)
			{
				sprite.sprite = sPullRight;
				anim.runtimeAnimatorController = aPullRight;
			}
			else if (boolPushing)
			{
				sprite.sprite = sPushRight;
				anim.runtimeAnimatorController = aPushRight;	
			}
			else if (onGround)
			{
				sprite.sprite = sWalkRight;
				anim.runtimeAnimatorController = aWalkRight;
			}
			else
			{
				sprite.sprite = sJumpRight;
				anim.runtimeAnimatorController = null;
			}

			sprite.flipX = true;
			rig.velocity = new Vector2(-movePower * modPullHor + movX, rig.velocity.y);
		}
		else if (
			Input.GetKey(KeyCode.RightArrow)
			)
		{
			if (
				gamobjPullTarget != null
				)
			{
				sprite.sprite = sPullRight;
				anim.runtimeAnimatorController = aPullRight;
			}
			else if (boolPushing)
			{
				sprite.sprite = sPushRight;
				anim.runtimeAnimatorController = aPushRight;	
			}
			else if (onGround)
			{
				sprite.sprite = sWalkRight;
				anim.runtimeAnimatorController = aWalkRight;
			}
			else
			{
				sprite.sprite = sJumpRight;
				anim.runtimeAnimatorController = null;
			}

			sprite.flipX = false;
			rig.velocity = new Vector2(movePower * modPullHor + movX, rig.velocity.y);
		}
		else
		{
			if (onGround)
			{
				sprite.sprite = sStandRight;
				anim.runtimeAnimatorController = null;
			}
			else
			{
				sprite.sprite = sJumpRight;
				anim.runtimeAnimatorController = null;
			}

			rig.velocity = new Vector2(0 + movX, rig.velocity.y);
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
			Input.GetKeyDown(KeyCode.Space) &&
			onGround
			)
		{
			intGravityState = (intGravityState + 1) % 3;
			rig.gravityScale = GetGravity() * Mathf.Sign(rig.gravityScale);
			GetGravity();
		}

		if (
			Input.GetKeyDown(KeyCode.Z) && onGround
			)
		{
			GameObject.Find("SoundManager").GetComponent<SoundManagerHandler>().playSound(
				GameObject.Find("SoundManager").GetComponent<SoundManagerHandler>().auGravityShift);
			InvertGravity();
			onGround = false;
		}

		if (
			gamobjPullTarget != null &&
			intGravityState < 2
			)
		{
			if (!GameObject.Find("SoundManager").GetComponent<AudioSource>().isPlaying)
			{
				GameObject.Find("SoundManager").GetComponent<SoundManagerHandler>().playSound(
					GameObject.Find("SoundManager").GetComponent<SoundManagerHandler>().auPull);
			}
			gamobjPullTarget.GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity;
		}

		if (
			Input.GetKeyDown(KeyCode.C)
			)
		{
			Application.LoadLevel(Application.loadedLevel);
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
			coll.gameObject.tag == "Block" &&
			gamobjPullTarget == null &&
			boolCouldPush && 
			transform.position.y - (transform.localScale.y / 3)
				< coll.gameObject.transform.position.y + (coll.gameObject.transform.localScale.y / 2)
			)
		{
			//boolPushing = true;
		}

 		if (
 			coll.gameObject.layer == 9 &&
 			(((Mathf.Sign(rig.gravityScale) > 0) && coll.gameObject.transform.position.y <= transform.position.y) ||
 			((Mathf.Sign(rig.gravityScale) < 0) && coll.gameObject.transform.position.y >= transform.position.y))
 			)
 			onGround = true;
    }

    void OnCollisionExit2D(Collision2D coll) {
    	boolPushing = false;
 		if (
 			coll.gameObject.layer == 9 &&
 			coll.gameObject.tag == "Block" &&
 			intGravityState > 0
 			)
 		{
 			coll.gameObject.GetComponent<Rigidbody2D>().velocity = 
 				new Vector2(0, coll.gameObject.GetComponent<Rigidbody2D>().velocity.y);
 		}
    }

    public bool isOnGround()
    {
    	return onGround;
    }

    void OnTriggerEnter2D(Collider2D coll) {
    	if (coll.gameObject.tag == "Pull")
    	{
    		boolCouldPush = true;
    		if (Input.GetKey(KeyCode.X) && onGround)
    		{
    			gamobjPullTarget = coll.gameObject.transform.parent.gameObject;
    		}
    		else
    		{
    			gamobjPullTarget = null;
    		}
    	}
    	else
    	{
    		boolCouldPush = false;
    	}
    }

    void OnTriggerStay2D(Collider2D coll) {
    	if (coll.gameObject.tag == "Pull")
    	{
    		if (Input.GetKey(KeyCode.X) && onGround)
    		{
    			gamobjPullTarget = coll.gameObject.transform.parent.gameObject;
    		}
    		else
    		{
    			gamobjPullTarget = null;
    		}
    	}
    }

    void OnTriggerExit2D(Collider2D coll) 
    {
 		if (coll.gameObject.tag == "Pull")
    	{
    		gamobjPullTarget = null;
    	}
    }
}