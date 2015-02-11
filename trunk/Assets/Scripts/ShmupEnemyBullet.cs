using UnityEngine;
using System.Collections;

public class ShmupEnemyBullet : MonoBehaviour
{
    public float speed;

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;
        position.x -= speed * Time.deltaTime;
        transform.position = position;
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
     if (collider.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}