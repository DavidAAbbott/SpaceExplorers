using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour
{
    public GameObject explosion;
    public bool randSpawn;
    public int SpawnRange;

    // Use this for initialization
    void Start()
    {
        if (randSpawn)
        {
            transform.position = Random.insideUnitCircle * SpawnRange;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Bullet")
        {
            Destroy(gameObject);
            Instantiate(explosion, transform.position, new Quaternion());
        }
    }
}