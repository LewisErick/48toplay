using UnityEngine;
using System.Collections;

public class PlayerCollisions : MonoBehaviour {

    public const string BLACKHOLE_TAG = "BlackHoleCenter"; //BlackHole & Boss
    public const string ASTEROID_TAG = "Asteroid";

	

    public GameObject explosion;

    private float force = 1000;

    private PlayerMovement playerController;
    private Rigidbody2D rb;

    void Start()
    {
        playerController = GetComponent<PlayerMovement>();
        rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.CompareTag(BLACKHOLE_TAG))
        {
            playerController.applyDamage(200);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(ASTEROID_TAG))
        {
            Vector2 velocity = other.GetComponent<Rigidbody2D>().velocity.normalized;
            Vector2 diff = (other.transform.position - this.transform.position);

            GameObject explosionGO = (GameObject)Instantiate(explosion, other.transform.position, other.transform.rotation);
            Destroy(explosionGO, 0.5f);
        }
    }

}
