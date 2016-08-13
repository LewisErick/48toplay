using UnityEngine;
using System.Collections;

public class BlackHole : MonoBehaviour {

    public GameObject initParticles;
    public GameObject endParticles;

    private float forceRadius = 1;
    private CircleCollider2D coll;

    void Start()
    {
        coll = GetComponent<CircleCollider2D>();
        forceRadius = coll.radius;   

        BlackHoleCreation();

        float timeToDestroy = 5f;
        Invoke("destroyBlackHole", timeToDestroy);;
    }

    //Genera los efectos del BlackHole.
    void BlackHoleCreation()
    {
        StartCoroutine(activeForce());

        //Particulas de inicio
        if (initParticles != null)
        {
            float _timeToDestroyParticles = 3f;
            GameObject particles = (GameObject)Instantiate(initParticles, this.transform.position, this.transform.rotation);
            Destroy(particles, _timeToDestroyParticles);
        }
    }

    //Activa la fuerza gravitacional del BlackHole
    IEnumerator activeForce()
    {
        PointEffector2D gravityEffect = GetComponent<PointEffector2D>();
        coll.enabled = false;
        gravityEffect.enabled = false;
        yield return new WaitForSeconds(3f);
        coll.enabled = true;
        gravityEffect.enabled = true;
    }

    //Destruye el BlackHole en un tiempo 
    void destroyBlackHole()
    {      
        if (endParticles != null)
        {
            float _timeToDestroyParticles = 3f;
            GameObject particles = (GameObject)Instantiate(endParticles, this.transform.position, this.transform.rotation);
            Destroy(particles, _timeToDestroyParticles);
        }
        Destroy(this.gameObject, 3f);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere (this.transform.position, forceRadius);
    }


}
