using UnityEngine;
using System.Collections;

public class Asteroid : MonoBehaviour {

    public const string PLAYER_TAG = "Player";
    public const string AIRSHIP_TAG = "Airship";

    public float speed = 10;

    private GameObject player;
    private Rigidbody2D rb;
    private Vector2 diff;

	void Start () 
    {
        player = GameObject.FindGameObjectWithTag(PLAYER_TAG);
        rb = GetComponent<Rigidbody2D>();

        diff = player.transform.position - this.transform.position;
	}
        
    void FixedUpdate()
    {
        MoveTowardsPlayer(diff);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {  
        if (coll.gameObject.CompareTag(AIRSHIP_TAG))
        {
            Destroy(this.gameObject);
        }    
    }

    void MoveTowardsPlayer(Vector2 _diff)
    {
        rb.AddForce(_diff * speed *Time.deltaTime);
    }

}
