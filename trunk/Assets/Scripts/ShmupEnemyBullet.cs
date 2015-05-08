using UnityEngine;
using System.Collections;

public class ShmupEnemyBullet : MonoBehaviour
{
    public bool shmupenemy = false;
    public bool bossbomb = false;
    public float turnspeed = 10f;
    public float bulletspeed = 8f;
    public GameObject explosion;
    public bool laserBoss = false;

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
            position.x -= bulletspeed * Time.deltaTime;
            transform.position = position;
        }
        if (!shmupenemy && !bossbomb)
        {
            transform.Rotate(Vector3.forward * -90, turnspeed * Time.deltaTime * 30f);
        }
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player" || collider.tag == "pBoundary" || collider.tag == "Ground")
        {
            if (bossbomb)
            {
                GameObject pNewObject;
                pNewObject = Instantiate(explosion, transform.position, new Quaternion()) as GameObject;
                pNewObject.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            }
            Destroy(gameObject);
        }
    }
    IEnumerator timer()
    {
        if (laserBoss)
        {
            yield return new WaitForSeconds(BossScript.bTime);
        }
        else
        {
            float time = Random.Range(0.8f, 1.3f);
            yield return new WaitForSeconds(time);
        }
        GameObject pNewObject;
        pNewObject = Instantiate(explosion, transform.position, new Quaternion()) as GameObject;
        pNewObject.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        Destroy(gameObject);
    }
}