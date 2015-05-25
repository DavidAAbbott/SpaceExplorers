using UnityEngine;
using System.Collections;

public class ProjectileEnemy : MonoBehaviour
{
    public float speed = 0.5f;
    public GameObject hitExplosion;

    public void Init(float ProjectileSpeed)
    {
        speed = ProjectileSpeed;
    }

    void Update()
    {
        transform.Translate(0.0f, speed, 0.0f);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Asteroid")
        {
            Destroy(gameObject);
        }

        if (collider.tag == "Player")
        {
            Destroy(gameObject);
            Instantiate(hitExplosion, transform.position, new Quaternion());
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