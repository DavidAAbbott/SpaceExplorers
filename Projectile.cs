using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
    public float speed = 0.5f;
    public bool mapMode;
    public bool bomb = false;
    public GameObject hitExplosion;
    public static int bullet1Dmg = 1;
    public static int bullet2Dmg = 2;
    public static int bullet3Dmg = 3;
    public static int bombDmg = 10;

    public void Init(float ProjectileSpeed)
    {
        speed = ProjectileSpeed;
    }

    void Update()
    {
        if (!bomb)
        {
            if (!mapMode)
            {
                transform.Translate(speed, 0.0f, 0.0f);
            }
            else
            {
                transform.Translate(0.0f, speed, 0.0f);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Asteroid")
        {
            Destroy(gameObject, 0.01f);
        }

        if (collider.tag == "Enemy" || collider.tag == "Worm")
        {
            Destroy(gameObject);
            Instantiate(hitExplosion, transform.position, new Quaternion());
        }
        if (collider.tag == "pBoundary")
        {
            Destroy(gameObject);
        }
        if (collider.tag == "Ground")
        {
            Destroy(gameObject);
            if(bomb)
            {
                Instantiate(hitExplosion, transform.position, new Quaternion());
                Vector2 place = transform.position;
                place.x += 0.2f;
                place.y += 0.2f;
                Instantiate(hitExplosion, place, new Quaternion());
                place.x -= 0.4f;
                place.y -= 0.4f;
                Instantiate(hitExplosion, place, new Quaternion());
            }
        }
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "Boundary")
        {
            Destroy(gameObject);
        }
    }
}