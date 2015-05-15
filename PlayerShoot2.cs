using UnityEngine;
using System.Collections;

public class PlayerShoot2 : MonoBehaviour 
{
    public float fireRate = 0.2f;
    public AudioClip ShotSound, triShotSound;
    public GameObject BulletP2, Bullet2P2, Bullet3P2, Bullet4P2, BombP2;
    public float PrimaryOffsetX, PrimaryOffsetY;
    public float SecondaryOffsetX, SecondaryOffsetY;
    private Score scores;
    public static bool canShoot2 = true;
    private float holdTimeP2 = 4f;
    public float holdTimeModifier = 10f;
    private float timer = 0f;
    private float timer2 = 0f;
    public float fireRateFirst = 0.2f;
    private float fireRate1, fireRateFirst1;

    void Start()
    {
        scores = GameObject.Find("Canvas").GetComponent<Score>();
    }
    void Update()
    {
        Vector2 inputs = Vector2.zero;
        if (canShoot2)
        {
            if (PlayerMov.KBcontrols2)
            {
                if (Input.GetKey(KeyCode.G))
                {
                    inputs = new Vector2(Input.GetAxis("KBShoot2"), Input.GetAxis("KBShoot2"));
                }
                if (Input.GetKeyDown(KeyCode.G))
                {
                    if (timer2 >= fireRateFirst1)
                    {
                        PrimaryShoot();
                        timer2 = 0f;
                    }
                }
                if (Input.GetKey(KeyCode.H))
                {
                    if (holdTimeP2 <= 15f)
                    {
                        holdTimeP2 += Time.deltaTime * holdTimeModifier;
                    }
                }
                else if (Input.GetKeyUp(KeyCode.H) && holdTimeP2 > 0)
                {
                    SecondaryShoot();
                }
            }
            else
            {
                inputs = new Vector2(Input.GetAxis("TriggersR_2"), Input.GetAxis("TriggersR_2"));

                if (Input.GetButton("X_2"))
                {
                    inputs = new Vector2(Input.GetAxis("X_2"), Input.GetAxis("X_2"));
                }

                if (Input.GetButtonDown("X_2"))
                {
                    if (timer2 >= fireRateFirst1)
                    {
                        PrimaryShoot();
                        timer2 = 0f;
                    }
                }

                if (Input.GetButton("LB_2") || Input.GetButton("A_2"))
                {
                    if (holdTimeP2 <= 15f)
                    {
                        holdTimeP2 += Time.deltaTime * holdTimeModifier;
                    }
                }
                else if (Input.GetButtonUp("LB_2") && holdTimeP2 > 0 || Input.GetButtonUp("A_2") && holdTimeP2 > 0)
                {
                    SecondaryShoot();
                }
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
    void PrimaryShoot()
    {
        if (scores.pCount2 == 2)
        {
            Shoot(Bullet2P2, PrimaryOffsetX, PrimaryOffsetY, false, holdTimeP2, transform.rotation.z);
            GetComponent<AudioSource>().PlayOneShot(ShotSound);
        }
        if (scores.pCount2 == 1)
        {
            Shoot(BulletP2, PrimaryOffsetX, PrimaryOffsetY, false, holdTimeP2, transform.rotation.z);
            GetComponent<AudioSource>().PlayOneShot(ShotSound);
        }
        if (scores.pCount2 == 3)
        {
            Shoot(Bullet3P2, PrimaryOffsetX, PrimaryOffsetY, false, holdTimeP2, transform.rotation.z);
            GetComponent<AudioSource>().PlayOneShot(ShotSound);
        }
        if (scores.pCount2 >= 4)
        {
            Shoot(Bullet4P2, PrimaryOffsetX, PrimaryOffsetY, false, holdTimeP2, 0.1f);
            Shoot(Bullet4P2, PrimaryOffsetX, PrimaryOffsetY, false, holdTimeP2, transform.rotation.z);
            Shoot(Bullet4P2, PrimaryOffsetX, PrimaryOffsetY, false, holdTimeP2, -0.1f);
            fireRate1 = 0.3f;
            fireRateFirst1 = 0.25f;
            GetComponent<AudioSource>().PlayOneShot(triShotSound);
        }
        if (scores.pCount2 < 4)
        {
            fireRate1 = fireRate;
            fireRateFirst1 = fireRateFirst;
        }
    }
    void SecondaryShoot()
    {
        if (scores.sCount2 > 0)
        {
            Shoot(BombP2, SecondaryOffsetX, SecondaryOffsetY, true, holdTimeP2, transform.rotation.z);
            holdTimeP2 = 4f;
            scores.sCount2--;
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
