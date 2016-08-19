using UnityEngine;
using System.Collections;

public class BossController : MonoBehaviour {


    [SerializeField]
    private int healthPoints;
    private bool isAirshipDamaged;

    private BossMotor bossMotor;

    public GameObject destroyParticles;

    public int maxHealth = 100;

    private SpriteRenderer spriteRend;


    void Start()
    {
        healthPoints = maxHealth; //Su vida inicial es la maxima
        bossMotor = GetComponent<BossMotor>(); 
        spriteRend = GetComponentInChildren<SpriteRenderer>();
    }
        

    //El Boss recibe daño. Si se le acaba la vida mata al Boss
    public void TakeDamage(int _damagePoints)
    {
        InvokeRepeating("SpriteDisabled", 0f, 0.5f);
        InvokeRepeating("SpriteEnabled", 0.3f, 0.5f);
        StartCoroutine(stopInvokes());
        
        healthPoints -= _damagePoints;

        if (!isAirshipDamaged && healthPoints <= 50)
        {
            DamageAirship();
        }
        else if (healthPoints <= 0)
        {
            Killed();
        }
    }

    //Muere el Boss. Destruye el GameObject e instancia particulas
    private void Killed()
    {
        Destroy(this.gameObject, 3f);
        if (destroyParticles != null)
        {
            GameObject particles = (GameObject) Instantiate(destroyParticles, this.transform.position, this.transform.rotation);
            Destroy(particles, 3f);

            StartCoroutine(ending());
        }
    }

    IEnumerator ending()
    {
        yield return new WaitForSeconds(3f);
        Application.LoadLevel("Ending.");
    }

    private void DamageAirship()
    {
        isAirshipDamaged = true;

        //DestroyShip

        //Active Asteroids
        bossMotor.ActiveDamageAirship();
    }

    void SpriteDisabled()
    {
        spriteRend.enabled = false;
    }

    void SpriteEnabled()
    {
        spriteRend.enabled = true;
    }

    IEnumerator stopInvokes()
    {
        yield return new WaitForSeconds(2f);
        CancelInvoke();
        SpriteEnabled();
    }

}