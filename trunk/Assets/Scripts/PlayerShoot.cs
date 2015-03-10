using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour
{
    public float fireRate = 0.2f;
    private float timeBetween = 0.0f;
    public AudioClip ShotSound;
    public GameObject Bullet, BulletP2, Bullet2, Bullet2P2, Bullet3, Bullet3P2;
    public float PrimaryOffsetX, PrimaryOffsetY;
    public float SecondaryOffsetX, SecondaryOffsetY;
    private Score scores;
    public bool WorldMap = false;
    public static bool canShoot = true;
    public static bool canShoot2 = true;
    public bool p2 = false;

    void Start()
    {
        if (WorldMap == false)
        {
            scores = GameObject.Find("Canvas").GetComponent<Score>();
        }
    }
    void Update()
    {
        Vector2 inputs = Vector2.zero;
        if (p2 && canShoot2)
        {
            if (PlayerMov.KBcontrols)
            {
                if (Input.GetKey(KeyCode.G))
                {
                    inputs = new Vector2(Input.GetAxis("KBShoot2"), Input.GetAxis("KBShoot2"));
                }
            }
            else
            {
                inputs = new Vector2(Input.GetAxis("TriggersR_2"), Input.GetAxis("TriggersR_2"));
            }
        }
        else if (!p2 && canShoot)
        {
            if (PlayerMov.KBcontrols)
            {
                if (Input.GetKey(KeyCode.Comma))
                {
                    inputs = new Vector2(Input.GetAxis("KBShoot"), Input.GetAxis("KBShoot"));
                }
            }
            else
            {
                inputs = new Vector2(Input.GetAxis("TriggersR_1"), Input.GetAxis("TriggersR_1"));
            }
        }
        if (inputs.sqrMagnitude <= 0.1f)
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
    void PrimaryShoot()
    {
        if (WorldMap == false)
        {
            GameObject pNewObject;

            if (p2)
            {
                if (scores.pCount == 2)
                {
                    Shoot(Bullet2P2, PrimaryOffsetX, PrimaryOffsetY);
                }
                if (scores.pCount == 3)
                {
                    Shoot(Bullet3P2, PrimaryOffsetX, PrimaryOffsetY);
                }
                else
                {
                    Shoot(BulletP2, PrimaryOffsetX, PrimaryOffsetY);
                }
            }
            else
            {
                if (scores.pCount == 2)
                {
                    Shoot(Bullet2, PrimaryOffsetX, PrimaryOffsetY);
                }
                if (scores.pCount == 3)
                {
                    Shoot(Bullet3, PrimaryOffsetX, PrimaryOffsetY);
                }
                else
                {
                    Shoot(Bullet, PrimaryOffsetX, PrimaryOffsetY);
                }
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