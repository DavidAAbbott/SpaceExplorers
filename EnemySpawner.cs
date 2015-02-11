using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

    public float SpawnRate;
    public GameObject Spawnee;

    float spawnTime;
    float spawnPositionX;
    float spawnRangeY;

	// Use this for initialization
	void Start () {
        spawnTime = Time.time;
        spawnRangeY = Camera.main.orthographicSize;
        spawnPositionX = Camera.main.aspect * spawnRangeY + 1.0f;
        spawnRangeY -= 1.0f;
	}
	
	// Update is called once per frame
	void Update () 
    {
	if(Time.time > spawnTime + SpawnRate)
    {
        float positionY = Random.Range(-spawnRangeY, spawnRangeY);
        Vector3 position = new Vector3(spawnPositionX, positionY, 0.0f);
        Instantiate(Spawnee, position, Quaternion.Euler(0, 0, 0));
        spawnTime = Time.time;
    }
	}
}
