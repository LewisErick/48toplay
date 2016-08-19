using UnityEngine;
using System.Collections;

public class Box : MonoBehaviour {

    public const string BLACKHOLE_TAG = "BlackHoleCenter"; //BlackHole & Boss

    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.CompareTag(BLACKHOLE_TAG))
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(BLACKHOLE_TAG))
        {
            Destroy(this.gameObject);
        }
    }
}
