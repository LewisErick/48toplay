using UnityEngine;
using System.Collections;

public class BlackHole : MonoBehaviour {

    public GameObject initParticles;
    public GameObject endParticles;

    private float forceRadius = 2.5f;
    private CircleCollider2D coll;

    void Awake()
    {
        float _scale = (Random.Range(0.8f, 1.2f));
        this.transform.localScale = new Vector2(_scale, _scale);
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, -2);
    }

    void Start()
    {
        coll = GetComponent<CircleCollider2D>();
        forceRadius = coll.radius;   

        BlackHoleCreation();

        float timeToDestroy = 2.5f;
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
