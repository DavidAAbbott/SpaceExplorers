using UnityEngine;
using System.Collections;

public class ShmupEnemy : MonoBehaviour {
    public int speed;
    public float FireRate;
    public float startWait = 2f;
    public GameObject explosion;
    public GameObject EnemyBullet;
    public float BulletSpawnX;
    public float BulletSpawnY;
    private Score scores;
    public int points = 50;

    void Start()
    {
        scores = GameObject.Find("Canvas").GetComponent<Score>();
        InvokeRepeating("Firing", startWait, FireRate);
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

    /*void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "LevelBoundary")
        {
            Destroy(gameObject);
        }
    }*/

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "pBullet")
        {
            Destroy(gameObject);
            Instantiate(explosion, transform.position, new Quaternion());
            scores.hit++;
            scores.timer += 0.5f;
            scores.combo++;

            if (scores.cmb == true)
            {
                scores.score += points * scores.combo;
            }
            else
            {
                scores.combo = 0;
                scores.score += points;
            }
        }
        if (collider.tag == "pBullet2")
        {
            Destroy(gameObject);
            Instantiate(explosion, transform.position, new Quaternion());
            scores.hit2++;
            scores.timer2 += 0.5f;
            scores.combo2++;

            if (scores.cmb2 == true)
            {
                scores.score2 += points * scores.combo2;
            }
            else
            {
                scores.combo2 = 0;
                scores.score2 += points;
            }
        }
    }
}