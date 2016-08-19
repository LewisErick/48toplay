using UnityEngine;
using System.Collections;

public class Asteroid : MonoBehaviour {

    public const string PLAYER_TAG = "Player";
    public const string BLACKHOLE_TAG = "BlackHole"; //BlackHole & Boss
    public const string EXPLOSION_TAG = "Explosion";

    public GameObject explosion;
    public GameObject initParticles;

    public float speed = 10;

    private GameObject player;
    private Rigidbody2D rb;
    private Vector2 diff;
    private Vector3 playerPos;


    void Awake()
    {
        GameObject particles = (GameObject)Instantiate(initParticles, this.transform.position, this.transform.rotation);
        Destroy(particles, 3f);
    }

	void Start () 
    {
        player = GameObject.FindGameObjectWithTag(PLAYER_TAG);
        rb = GetComponent<Rigidbody2D>();
        playerPos = player.transform.position;

        diff = playerPos - this.transform.position;
	}
        
    void FixedUpdate()
    {
        MoveTowardsPlayer(diff);
        this.transform.localRotation = Quaternion.FromToRotation(this.transform.position, playerPos);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(PLAYER_TAG) || other.CompareTag(BLACKHOLE_TAG) || other.CompareTag(EXPLOSION_TAG))
        {
            GameObject explosionGO = (GameObject)Instantiate(explosion, other.transform.position, other.transform.rotation);
            Destroy(explosionGO, 1f);
        }
        else
        {
            Destroy(this.gameObject);
            GameObject explosionGO = (GameObject)Instantiate(explosion, other.transform.position, other.transform.rotation);
            Destroy(explosionGO, 1f);
            GameObject particles = (GameObject)Instantiate(initParticles, this.transform.position, this.transform.rotation);
            Destroy(particles, 3f);
        }
    }

    void MoveTowardsPlayer(Vector2 _diff)
    {
        rb.AddForce(_diff * speed *Time.deltaTime);
    }

}
