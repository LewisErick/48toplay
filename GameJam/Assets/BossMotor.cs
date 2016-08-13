using UnityEngine;
using System.Collections;

public class BossMotor : MonoBehaviour {


    public GameObject blackHole;

    public float yArea = 5f;
    public float xArea = 5f ;

	void Start () 
    {

	
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
}
