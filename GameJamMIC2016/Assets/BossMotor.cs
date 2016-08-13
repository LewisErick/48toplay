using UnityEngine;
using System.Collections;

public class BossMotor : MonoBehaviour {

    [Header("Black Hole")]
    public GameObject blackHole;
    public float yArea = 5f;
    public float xArea = 5f ;

    [Header("Asteroid")]
    public GameObject asteroid;
    public Transform asteroidSpawnerPositionUp;
    public Transform asteroidSpawnerPositionDown;
    public float xAsteroidSpace = 5f;




	void Start () 
    {

        ActiveDamageAirship();
	}
	
	void Update () 
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            SpawnBlackHole();
        }	

	}

    //Instancia BlackHole
    void SpawnBlackHole()
    {
        Vector2 spawnerPoint = new Vector2((Random.Range(this.transform.position.x + 1, xArea)), (Random.Range(this.transform.position.y - 2, yArea )));
        Instantiate(blackHole, spawnerPoint, this.transform.rotation);
    }

    void SpawnAsteroids()
    {      
        Transform _spawnSpace;
        int upOrDownValue = Random.Range(0, 2); //Spawn 0: Down, 1: Up

        if (upOrDownValue == 0)
        {
            _spawnSpace = asteroidSpawnerPositionDown;
        }
        else
        {
            _spawnSpace = asteroidSpawnerPositionUp;
        }

        float _xSpace = Random.Range(_spawnSpace.position.x - xAsteroidSpace, _spawnSpace.position.x + xAsteroidSpace);

        Vector2 _spawnPoint = new Vector2(_xSpace , _spawnSpace.position.y);

        Instantiate(asteroid, _spawnPoint, this.transform.rotation);

       
    }

    public void ActiveDamageAirship()
    {
        InvokeRepeating("SpawnAsteroids", 3, 2f);
    }
}
