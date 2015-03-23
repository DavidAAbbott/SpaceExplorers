using UnityEngine;
using System.Collections;

public class ShmupEnemyBullet : MonoBehaviour
{
    public bool shmupenemy = false;
    public bool bossbomb = false;
    public GameObject explosion;

    void Start()
    {
        if (bossbomb)
        {
            StartCoroutine("timer");
        }
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
    IEnumerator timer()
    {
        float time = Random.RandomRange(0.8f, 1.15f);
        yield return new WaitForSeconds(time);
        GameObject pNewObject;
        pNewObject = Instantiate(explosion, transform.position, new Quaternion()) as GameObject;
        pNewObject.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        Destroy(gameObject);
    }
}