using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {
    public float fireRate = 0.2f;
    private float timeBetween = 0.0f;
    public AudioClip ShotSound;
    public GameObject Bullet, Bullet2, Bullet3;
    private Score scores;

    void Start()
    {
        scores = GameObject.Find("UI").GetComponent<Score>();
    }
    void Update()
    {
        Vector2 inputs = new Vector2(Input.GetAxis("TriggersR_1"), Input.GetAxis("TriggersR_1"));
        if (inputs.sqrMagnitude < 0.1f)
        {
            //Reset
            timeBetween= 0.0f;
            return;
        }

        /*if (Input.GetKey(KeyCode.Z)) {

        }
        else {
            timeBetween = 0f;
            return;
        }
        */

        timeBetween += Time.deltaTime;
        int shotsFired = (int)(timeBetween / fireRate);

        for (int i = 0; i < shotsFired; ++i) 
        {
            Shoot();
        }

        if (shotsFired > 0) {
            audio.PlayOneShot(ShotSound, 1F);
        }

        timeBetween %= fireRate;
    }
    void Shoot()
    {
        GameObject pNewObject;
        if (scores.pCount == 2)
        {
            pNewObject = Instantiate(Bullet2) as GameObject;
            pNewObject.transform.rotation = transform.rotation;
            Vector2 pos = new Vector2(transform.position.x + 0.5f, transform.position.y - 0.1f);
            pNewObject.transform.position = pos;
        }
        if (scores.pCount == 3)
        {
            pNewObject = Instantiate(Bullet3) as GameObject;
            pNewObject.transform.rotation = transform.rotation;
            Vector2 pos = new Vector2(transform.position.x + 0.5f, transform.position.y - 0.1f);
            pNewObject.transform.position = pos;
        }
        else
        {
            pNewObject = Instantiate(Bullet) as GameObject;
            pNewObject.transform.rotation = transform.rotation;
            Vector2 pos = new Vector2(transform.position.x + 0.5f, transform.position.y - 0.1f);
            pNewObject.transform.position = pos;
        }
    }
}