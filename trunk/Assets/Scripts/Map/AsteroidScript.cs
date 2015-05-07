using UnityEngine;
using System.Collections;

public class AsteroidScript : MonoBehaviour
{
    public float ForceMin, ForceMax, TorqueMin, TorqueMax, PiecesMin, PiecesMax, xLow, xHigh, yLow, yHigh;
    public GameObject explosion, asteroidbits1, asteroidbits2;
    public AudioClip HitSound;
    public int SpawnRange, Health;
    public bool randSpawn, isBig;

    void Start()
    {
        if (randSpawn)
        {
            transform.position = Random.insideUnitCircle * SpawnRange;
        }

        float force = Random.Range(ForceMin, ForceMax);
        float torque = Random.Range(TorqueMin, TorqueMax);

        float x = Random.Range(xLow, xHigh);
        float y = Random.Range(yLow, yHigh);

        GetComponent<Rigidbody2D>().AddForce(force * new Vector2(x, y));
        GetComponent<Rigidbody2D>().AddTorque(torque);
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Bullet" || collider.tag == "p1Bullet" && Health > 0)
        {
            Destroy(gameObject);
            Instantiate(explosion, transform.position, new Quaternion());

            if (isBig == true)
            {
                float NumberOfPieces = Random.Range(PiecesMin, PiecesMax);

                for (int i = 0; i < NumberOfPieces; i++)
                {
                    Instantiate(asteroidbits1, transform.position, Quaternion.identity);
                    Instantiate(asteroidbits2, transform.position, Quaternion.identity);
                }
            }
        }
    }
}