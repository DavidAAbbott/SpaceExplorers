using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
    public float speed = 0.5f;
    public bool mapMode;

    public void Init(float ProjectileSpeed)
    {
        speed = ProjectileSpeed;
    }

    void Update()
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

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Asteroid")
        {
            Destroy(gameObject, 0.01f);
        }

        if (collider.tag == "Enemy")
        {
            Destroy(gameObject, 0.01f);
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