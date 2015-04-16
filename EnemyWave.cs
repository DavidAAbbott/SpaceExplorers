using UnityEngine;
using System.Collections;

public class EnemyWave : MonoBehaviour {
    //public GameObject[] enemies;
    public GameObject pickup, lastEnemy;
    public static int numOfEnemies = 0;

	void Start () {

	}
	void Update () {
	    if(numOfEnemies == 4)
        {
            Instantiate(pickup, lastEnemy.transform.position, new Quaternion());
            numOfEnemies = 0;
            Destroy(gameObject);
        }
	}
}
