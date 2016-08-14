﻿using UnityEngine;
using System.Collections;

public class BossMotor : MonoBehaviour {

    public const string PLAYER_TAG = "Player";

    [Header("Black Hole")]
    public GameObject blackHole;
    public float yArea = 5f;
    public float xArea = 5f ;

    [Header("Asteroid")]
    public GameObject asteroid;
    public Transform asteroidSpawnerPositionUp;
    public Transform asteroidSpawnerPositionDown;
    public float xAsteroidSpace = 5f;

    private Animator animator;


	void Start () 
    {
        animator = GetComponentInChildren<Animator>();
        InvokeRepeating("SpawnBlackHole", 2f, 4f);

        ActiveDamageAirship();
	}
	
	void Update () 
    {

	}

    //Instancia BlackHole
    void SpawnBlackHole()
    {
        animator.SetTrigger("cast");
        for (int i = 0; i < 3; i++)
        {
            Vector2 spawnerPoint = new Vector2((Random.Range(this.transform.position.x + 1, xArea)), (Random.Range(this.transform.position.y - 2, yArea )));
            Instantiate(blackHole, spawnerPoint, this.transform.rotation);
        }
       
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
        CancelInvoke();
        animator.SetTrigger("charge");

       

        //Destroy shipa

        StartCoroutine(destroyShip());

        InvokeRepeating("SpawnBlackHole", 6f, 6f);
        InvokeRepeating("SpawnAsteroids", 3, 2f);
    }

    IEnumerator destroyShip()
    {
        yield return new WaitForSeconds(2f);

        //Spawn BlackHoles and destroy ship
        Vector2 spawnerPoint = new Vector2((Random.Range(this.transform.position.x + 1, xArea - 3)), (Random.Range(this.transform.position.y - 2, yArea )));
        Instantiate(blackHole, spawnerPoint, this.transform.rotation);
        spawnerPoint = new Vector2((Random.Range(this.transform.position.x + 1, xArea - 3)), (Random.Range(this.transform.position.y - 2, yArea )));
        Instantiate(blackHole, spawnerPoint, this.transform.rotation);
        spawnerPoint = new Vector2((Random.Range(this.transform.position.x + 1, xArea - 3)), (Random.Range(this.transform.position.y - 2, yArea )));
        Instantiate(blackHole, spawnerPoint, this.transform.rotation);

        PlayerMovement playerMove = GameObject.FindGameObjectWithTag(PLAYER_TAG).GetComponent<PlayerMovement>();
        playerMove.enabled = false;
        
        yield return new WaitForSeconds(3f);
        playerMove.enabled = true;
    }
}
