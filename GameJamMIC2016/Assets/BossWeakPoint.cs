using UnityEngine;
using System.Collections;

public class BossWeakPoint : MonoBehaviour {

    public const string BLOCK_TAG = "Block";

    private int blockDamagePoints = 30;

    private BossController bossController;

    void Start()
    {
        bossController = GetComponentInParent<BossController>();
    }
        
    void OnTriggerEnter2D(Collider2D other)
    {
        //Si la colision es con un bloque destruye el bloque y le baja vida al Bos.
        if (other.tag.Equals(BLOCK_TAG))
        {
            Destroy(other.gameObject);
            bossController.TakeDamage(blockDamagePoints);
            blockDamagePoints = 20;
        }
    }
}
