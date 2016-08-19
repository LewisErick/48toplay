using UnityEngine;
using System.Collections;

public class PlayerCollisions : MonoBehaviour {

    public const string BLACKHOLE_TAG = "BlackHoleCenter"; //BlackHole & Boss
    public const string ASTEROID_TAG = "Asteroid";

    

    public GameObject explosion;
    public GameObject particles;

    private float force = 1000;

    private PlayerMovement playerController;
    private Rigidbody2D rb;

    private int intDeadWait = 0;

    void Start()
    {
        playerController = GetComponent<PlayerMovement>();
        rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(BLACKHOLE_TAG))
        {
            KillPlayer();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(ASTEROID_TAG))
        {
            Vector2 velocity = other.GetComponent<Rigidbody2D>().velocity.normalized;
            Vector2 diff = (other.transform.position - this.transform.position);

            //GameObject explosionGO = (GameObject)Instantiate(explosion, other.transform.position, other.transform.rotation);
            //Destroy(explosionGO, 0.5f);
        }
        else if (other.gameObject.CompareTag(BLACKHOLE_TAG))
        {
            KillPlayer();
        }
    }


    void KillPlayer()
    {

        intDeadWait = 300;
        playerController.applyDamage(200);
        Instantiate(particles, this.transform.position, this.transform.rotation);
        this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        this.gameObject.GetComponent<PlayerMovement>().enabled = false;
        StartCoroutine(restart());
    }

    void Update()
    {
    }

    IEnumerator restart()
    {
        yield return new WaitForSeconds(3f);
        Application.LoadLevel(Application.loadedLevel);
    }

}
