using UnityEngine;
using System.Collections;

public class ShmupEnemy : MonoBehaviour
{
    public int speed;
    public float FireRate;
    public GameObject explosion;
    public GameObject EnemyBullet;
    public float BulletSpawnX;
    public float BulletSpawnY;
    void Start()
    {
        InvokeRepeating("Firing", FireRate, FireRate);
    }

    void Update()
    {
        Movement();
    }

    void Movement()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    void Firing()
    {
        Vector3 position = transform.position;
        position.x += BulletSpawnX;
        position.y += BulletSpawnY;
        Instantiate(EnemyBullet, position, Quaternion.Euler(0, 0, 180));
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "Boundary")
        {
            Destroy(gameObject);
        }
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