using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour
{
    public float fireRate = 0.2f;
    private float timeBetween = 0.0f;
    public AudioClip ShotSound;
    public GameObject Bullet, Bullet2, Bullet3;
    public float PrimaryOffsetX, PrimaryOffsetY;
    public float SecondaryOffsetX, SecondaryOffsetY;
    private Score scores;
    public bool WorldMap = false;
    public static bool canShoot = true;

    void Start()
    {
        if (WorldMap == false)
        {
            scores = GameObject.Find("Canvas").GetComponent<Score>();
        }
    }
    void Update()
    {
        if (canShoot)
        {
            Vector2 inputs = Vector2.zero;
            if (PlayerMov.KBcontrols)
            {
                inputs = new Vector2(Input.GetAxis("KBShoot"), Input.GetAxis("KBShoot"));
            }
            else
            {
                inputs = new Vector2(Input.GetAxis("TriggersR_1"), Input.GetAxis("TriggersR_1"));
            }
            if (inputs.sqrMagnitude < 0.1f)
            {
                //Reset
                timeBetween = 0.0f;
                return;
            }

            timeBetween += Time.deltaTime;
            int shotsFired = (int)(timeBetween / fireRate);

            for (int i = 0; i < shotsFired; ++i)
            {
                PrimaryShoot();
            }
            if (shotsFired > 0)
            {
                audio.PlayOneShot(ShotSound, 1F);
            }

            timeBetween %= fireRate;
        }
    }
    void PrimaryShoot()
    {
        if (WorldMap == false)
        {
            GameObject pNewObject;

            if (scores.pCount == 2)
            {
                Shoot(Bullet2, PrimaryOffsetX, PrimaryOffsetY);
            }
            if (scores.pCount == 3)
            {
                Shoot(Bullet3, PrimaryOffsetX, PrimaryOffsetY);
            }
            if (scores.pCount == 4)
            {
                Shoot(Bullet3, PrimaryOffsetX, PrimaryOffsetY);
            }
            if (scores.pCount == 5)
            {
                Shoot(Bullet3, PrimaryOffsetX, PrimaryOffsetY);
            }
            else
            {
                Shoot(Bullet, PrimaryOffsetX, PrimaryOffsetY);
            }
        }

        else if (WorldMap == true)
        {
            Shoot(Bullet, PrimaryOffsetX, PrimaryOffsetY);
        }
    }
    void SecondaryShoot()
    {
        if (WorldMap == false)
        {
            GameObject pNewObject;

            if (scores.pCount == 2)
            {
                Shoot(Bullet2, SecondaryOffsetX, SecondaryOffsetY);
            }
            if (scores.pCount == 3)
            {
                Shoot(Bullet3, SecondaryOffsetX, SecondaryOffsetY);
            }
            else
            {
                Shoot(Bullet, SecondaryOffsetX, SecondaryOffsetY);
            }
        }
    }
    void Shoot(GameObject bullet, float offsetx, float offsety)
    {
        GameObject pNewObject;
        pNewObject = Instantiate(bullet) as GameObject;
        pNewObject.transform.rotation = transform.rotation;
        Vector2 pos = new Vector2(transform.position.x + offsetx, transform.position.y + offsety);
        pNewObject.transform.position = pos;
    }
}