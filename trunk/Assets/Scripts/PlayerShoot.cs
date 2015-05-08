using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour
{ 
    public float fireRate = 0.2f;
    public AudioClip ShotSound, triShotSound;
    public GameObject Bullet, Bullet2, Bullet3, Bullet4, Bomb;
    public float PrimaryOffsetX, PrimaryOffsetY;
    public float SecondaryOffsetX, SecondaryOffsetY;
    private Score scores;
    public bool WorldMap = false;
    public static bool canShoot = true;
    private float holdTime = 4f;
    public float holdTimeModifier = 10f;
    private float timer = 0f;
    private float timer2 = 0f;
    public float fireRateFirst = 0.2f;
    private float fireRate1, fireRateFirst1;

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

        if (canShoot)
        {
            if (PlayerMov.KBcontrols)
            {
                if (Input.GetKey(KeyCode.Comma))
                {
                    inputs = new Vector2(Input.GetAxis("KBShoot"), Input.GetAxis("KBShoot"));
                }
                if (Input.GetKeyDown(KeyCode.Comma))
                {
                    if (timer2 >= fireRateFirst1)
                    {
                        PrimaryShoot();
                        timer2 = 0f;
                    }
                }
                if (Input.GetKey(KeyCode.Period))
                {
                    if (holdTime <= 15f)
                    {
                        holdTime += Time.deltaTime * holdTimeModifier;
                    }
                }
                else if(Input.GetKeyUp(KeyCode.Period) && holdTime > 0)
                {
                    SecondaryShoot();
                }
            }
            else
            {
                inputs = new Vector2(Input.GetAxis("TriggersR_1"), Input.GetAxis("TriggersR_1"));

                if (Input.GetButton("X_1"))
                {
                    inputs = new Vector2(Input.GetAxis("X_1"), Input.GetAxis("X_1"));
                }
                if (Input.GetButtonDown("X_1"))
                {
                    if (timer2 >= fireRateFirst1)
                    {
                        PrimaryShoot();
                        timer2 = 0f;
                    }
                }

                if (Input.GetButton("LB_1") || Input.GetButton("B_1"))
                {
                    if (holdTime <= 15f)
                    {
                        holdTime += Time.deltaTime * holdTimeModifier;
                    }
                }
                else if (Input.GetButtonUp("LB_1") && holdTime > 0 || Input.GetButtonUp("B_1") && holdTime > 0)
                {
                    SecondaryShoot();
                }
            }

            timer += Time.deltaTime;
            timer2 += Time.deltaTime;

            if (inputs.sqrMagnitude >= 0.1f)
            {
                if (timer >= fireRate1)
                {
                    PrimaryShoot();
                    timer = timer - fireRate1;
                }
            }
            if (inputs.sqrMagnitude <= 0.1f)
            {
                timer = 0f;
            }
        }
    }
    void PrimaryShoot()
    {
        if (WorldMap == false)
        {
            if (scores.pCount == 2)
            {
                Shoot(Bullet2, PrimaryOffsetX, PrimaryOffsetY, false, holdTime, transform.rotation.z);
                GetComponent<AudioSource>().PlayOneShot(ShotSound);
            }
            if (scores.pCount == 1)
            {
                Shoot(Bullet, PrimaryOffsetX, PrimaryOffsetY, false, holdTime, transform.rotation.z);
                GetComponent<AudioSource>().PlayOneShot(ShotSound);
            }
            if (scores.pCount == 3)
            {
                Shoot(Bullet3, PrimaryOffsetX, PrimaryOffsetY, false, holdTime, transform.rotation.z);
                GetComponent<AudioSource>().PlayOneShot(ShotSound);
            }
            if (scores.pCount >= 4)
            {
                Shoot(Bullet4, PrimaryOffsetX, PrimaryOffsetY, false, holdTime, 0.1f);
                Shoot(Bullet4, PrimaryOffsetX, PrimaryOffsetY, false, holdTime, transform.rotation.z);
                Shoot(Bullet4, PrimaryOffsetX, PrimaryOffsetY, false, holdTime, -0.1f);
                fireRate1 = 0.3f;
                fireRateFirst1 = 0.25f;
                GetComponent<AudioSource>().PlayOneShot(triShotSound);
             }
             if (scores.pCount < 4)
             {
                fireRate1 = fireRate;
                fireRateFirst1 = fireRateFirst;
             }
        }

        else if (WorldMap == true)
        {
            Shoot(Bullet, PrimaryOffsetX, PrimaryOffsetY, false, holdTime, transform.rotation.z);
        }
    }
    void SecondaryShoot()
    {
        if (WorldMap == false)
        {
            if (scores.sCount > 0)
            {
                Shoot(Bomb, SecondaryOffsetX, SecondaryOffsetY, true, holdTime, transform.rotation.z);
                holdTime = 4f;
                scores.sCount--;
            }
        }
    }
    void Shoot(GameObject bullet, float offsetx, float offsety, bool addforce, float holdTimen, float rotation)
    {
        GameObject pNewObject;
        pNewObject = Instantiate(bullet) as GameObject;
        Quaternion rot = transform.rotation;
        rot = Quaternion.EulerAngles(0, 0, rotation);
        pNewObject.transform.rotation = rot;
        Vector2 pos = new Vector2(transform.position.x + offsetx, transform.position.y + offsety);
        pNewObject.transform.position = pos;
        if (addforce)
        {
            pNewObject.GetComponent<Rigidbody2D>().velocity = new Vector2(holdTimen, 0);
        }
    }
}