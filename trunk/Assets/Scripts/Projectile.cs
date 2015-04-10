using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
    public float speed = 0.5f;
    public bool mapMode;
    public bool bomb = false;
    public GameObject hitExplosion;
    public static int bullet1Dmg = 1;
    public static int bullet2Dmg = 3;
    public static int bullet3Dmg = 5;
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

        if (collider.tag == "Enemy")
        {
            Destroy(gameObject, 0.01f);
            Instantiate(hitExplosion, transform.position, new Quaternion());
        }
        if (collider.tag == "pBoundary")
        {
            Destroy(gameObject);
        }
        if (collider.tag == "Ground")
        {
            Destroy(gameObject);
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