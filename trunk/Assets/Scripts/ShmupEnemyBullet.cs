using UnityEngine;
using System.Collections;

public class ShmupEnemyBullet : MonoBehaviour
{
    public bool shmupenemy = false;

    void Start()
    {
    }
    void Update()
    {
        if (shmupenemy)
        {
            Vector3 position = transform.position;
            position.x -= 8f * Time.deltaTime;
            transform.position = position;
        }
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player" || collider.tag == "pBoundary" || collider.tag == "Ground")
        {
            Destroy(gameObject);
        }
    }
}