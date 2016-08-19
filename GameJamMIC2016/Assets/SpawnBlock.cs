using UnityEngine;
using System.Collections;

public class SpawnBlock : MonoBehaviour {

    public float xBlockSpace = 3f;

    public GameObject blockprefab;
    public GameObject initParticles;

    private Transform _spawnSpace;

	void Start () {

        _spawnSpace = this.transform;

        InvokeRepeating("SpawningBlocks", 10, 10);


	}


    void SpawningBlocks()
    {
        float _xSpace = Random.Range(_spawnSpace.position.x - xBlockSpace, _spawnSpace.position.x + xBlockSpace);

        Vector3 _spawnPoint = new Vector3(_xSpace , _spawnSpace.position.y, -2);

        GameObject dur = (GameObject)Instantiate(blockprefab, _spawnPoint, this.transform.rotation);
        dur.transform.position = new Vector3(dur.transform.position.x, dur.transform.position.y, -2);
        GameObject.Find("Player").GetComponent<PlayerMovement>().GetMaterials();
        GameObject particles = (GameObject)Instantiate(initParticles, _spawnPoint, this.transform.rotation);
        Destroy(particles, 3f);
    }

}
