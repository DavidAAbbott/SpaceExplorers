using UnityEngine;
using System.Collections;

public class ShmupEnemyBullet : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
    }
     void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player" || collider.tag == "pBoundary")
        {
            Destroy(gameObject);
        }
    }
}