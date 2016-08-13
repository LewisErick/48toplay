using UnityEngine;
using System.Collections;

public class Asteroid : MonoBehaviour {

    public const string PLAYER_TAG = "Player";
    public const string BLACKHOLE_TAG = "BlackHole"; //BlackHole & Boss
    public const string EXPLOSION_TAG = "Explosion";

    public GameObject explosion;

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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(PLAYER_TAG) || other.CompareTag(BLACKHOLE_TAG) || other.CompareTag(EXPLOSION_TAG))
        {
            return;
        }
        Destroy(this.gameObject);
        GameObject explosionGO = (GameObject)Instantiate(explosion, other.transform.position, other.transform.rotation);
        Destroy(explosionGO, 1f);
    }



    void MoveTowardsPlayer(Vector2 _diff)
    {
        rb.AddForce(_diff * speed *Time.deltaTime);
    }

}
