using UnityEngine;
using System.Collections;

public class EnemyWave : MonoBehaviour {
    public GameObject pickup;
    private GameObject pickupSpawn;
    public bool powerup = false;

	void Start () {
        pickupSpawn = transform.Find("PickupSpawn").gameObject;
	}
	void Update () {
        if (powerup)
        {
            if (transform.childCount == 1)
            {
                Instantiate(pickup, pickupSpawn.transform.position, new Quaternion());
                Destroy(gameObject);
            }
        }
	}
}
