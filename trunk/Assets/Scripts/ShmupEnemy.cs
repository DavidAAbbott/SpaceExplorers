using UnityEngine;
using System.Collections;

public class ShmupEnemy : MonoBehaviour
{
    public float speed;
    public float FireRate = 0.3f;
    public GameObject explosion;
    public GameObject EnemyBullet;
    public float BulletSpawnX;
    public float BulletSpawnY;
    private Score scores;
    public int points = 50;
    public int numberOfShots = 3;
    public float waitTime = 0.5f;
    public bool canFire = true;
    public int HP = 5;

    void Start()
    {
        scores = GameObject.Find("Canvas").GetComponent<Score>();
        if (canFire)
        {
            StartCoroutine(Firing());
        }
    }

    void Update()
    {
        Movement();
        if(HP <= 0)
        {
            Instantiate(explosion, transform.position, new Quaternion());
            Destroy(gameObject);
        }
    }

    void Movement()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    void Fire()
    {
        Vector3 position = transform.position;
        position.x += BulletSpawnX;
        position.y += BulletSpawnY;
        Instantiate(EnemyBullet, position, Quaternion.Euler(0, 0, 0));
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Player")
        {
            Destroy(gameObject);
        }
        if (collider.tag == "p1Bullet" || collider.tag == "p1Bullet2" || collider.tag == "p1Bullet3" || collider.tag == "p1Bomb")
        {
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
        if (collider.tag == "p2Bullet" || collider.tag == "p2Bullet2" || collider.tag == "p2Bullet3" || collider.tag == "p2Bomb")
        {
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
        if (collider.tag == "p1Bullet" || collider.tag == "p2Bullet")
        {
            HP -= Projectile.bullet1Dmg;
        }
        if (collider.tag == "p1Bullet3" || collider.tag == "p2Bullet2")
        {
            HP -= Projectile.bullet2Dmg;
        }
        if (collider.tag == "p1Bullet3" || collider.tag == "p2Bullet3")
        {
            HP -= Projectile.bullet3Dmg;
        }
        if (collider.tag == "p1Bomb" || collider.tag == "p2Bomb")
        {
            HP -= Projectile.bombDmg;
        }
        if (collider.tag == "pBoundary")
        {
            Destroy(gameObject);
        }
    }
    IEnumerator Firing()
    {
        yield return new WaitForSeconds(waitTime);
        for (int i = 0; i < numberOfShots; i++)
        {
            Fire();
            yield return new WaitForSeconds(FireRate);
        }
    }
}