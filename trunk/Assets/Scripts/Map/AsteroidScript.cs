using UnityEngine;
using System.Collections;

public class AsteroidScript : MonoBehaviour {
    public float ForceMin, ForceMax, TorqueMin, TorqueMax, xvalue, yvalue;
    public GameObject explosion;
    public GameObject asteroidbits1;
    public GameObject asteroidbits2;
    public int NumberOfPieces;
    public int SpawnRange;
    public bool randSpawn;
    public bool isBig;

    void Start()
    {
        if(randSpawn)
        {
            transform.position = Random.insideUnitCircle * SpawnRange;
        }

        float force = Random.Range(ForceMin, ForceMax);
        float x = Random.Range(xvalue, yvalue);
        float y = Random.Range(xvalue, yvalue);
        rigidbody2D.AddForce(force * new Vector2(x, y));

        float torque = Random.Range(TorqueMin, TorqueMax);
        rigidbody2D.AddTorque(torque);
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Bullet" || collider.tag == "pBullet")
        {
            Destroy(gameObject);
            if (isBig == true)
            {
                for (int i = 0; i < NumberOfPieces; i++)
                {
                    Instantiate(asteroidbits1, transform.position, Quaternion.identity);
                    Instantiate(asteroidbits2, transform.position, Quaternion.identity);
                }
            }
            Instantiate(explosion, transform.position, new Quaternion());
        }
    }
}