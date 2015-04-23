using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour
{
    public float fireRate = 0.2f;
    public AudioClip ShotSound;
    public GameObject Bullet, BulletP2, Bullet2, Bullet2P2, Bullet3, Bullet3P2, Bullet4, Bullet4P2, Bomb, BombP2;
    public float PrimaryOffsetX, PrimaryOffsetY;
    public float SecondaryOffsetX, SecondaryOffsetY;
    private Score scores;
    public bool WorldMap = false;
    public static bool canShoot = true;
    public static bool canShoot2 = true;
    public bool p2 = false;
    private float holdTime = 4f;
    private float holdTimeP2 = 4f;
    public float holdTimeModifier = 10f;
    public int button;
    public static bool shoot = false;

    void Start()
    {
        InvokeRepeating("PrimaryShoot", 0f, fireRate);
        if (WorldMap == false)
        {
            scores = GameObject.Find("Canvas").GetComponent<Score>();
        }
    }
    void Update()
    {   
        if(Input.GetKeyUp(KeyCode.Alpha2))
        {
            scores.pCount++;
        }
        Vector2 inputs = Vector2.zero;
        if (p2 && canShoot2)
        {
            if (PlayerMov.KBcontrols)
            {
                if (Input.GetKey(KeyCode.G))
                {
                    inputs = new Vector2(Input.GetAxis("KBShoot2"), Input.GetAxis("KBShoot2"));

                    if (inputs.sqrMagnitude >= 0.1f)
                    {
                        shoot = true;
                    }
                    else
                    {
                        shoot = false;
                    }
                }
                if (Input.GetKeyDown(KeyCode.G))
                {
                    PrimaryShoot();
                }
                if (Input.GetKeyUp(KeyCode.G))
                {
                    shoot = false;
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

                if (inputs.sqrMagnitude >= 0.1f)
                {
                    shoot = true;
                }
                else
                {
                    shoot = false;
                }

                if (Input.GetButton("LB_2") || Input.GetButton("B_2"))
                {
                    if (holdTimeP2 <= 15f)
                    {
                        holdTimeP2 += Time.deltaTime * holdTimeModifier;
                    }
                }
                else if (Input.GetButtonUp("LB_2") && holdTimeP2 > 0 || Input.GetButtonUp("B_2") && holdTimeP2 > 0)
                {
                    SecondaryShoot();
                }
            }
        }
        else if (!p2 && canShoot)
        {
            if (PlayerMov.KBcontrols)
            {
                if (Input.GetKey(KeyCode.Comma))
                {
                    inputs = new Vector2(Input.GetAxis("KBShoot"), Input.GetAxis("KBShoot"));

                    if (inputs.sqrMagnitude >= 0.1f)
                    {
                        shoot = true;
                    }
                    else
                    {
                        shoot = false;
                    }
                }
                if (Input.GetKeyDown(KeyCode.Comma))
                {
                    PrimaryShoot();
                }
                if (Input.GetKeyUp(KeyCode.Comma))
                {
                    shoot = false;
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

                if (inputs.sqrMagnitude >= 0.1f)
                {
                    shoot = true;
                }
                else
                {
                    shoot = false;
                }
                if (Input.GetButtonDown("X_1"))
                {
                    shoot = true;
                    PrimaryShoot();
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
        }
        
        /*if (inputs.sqrMagnitude <= 0.5f)
        {
            //Reset
            timeBetween = 0.0f;
            return;
        }
        if (inputs.sqrMagnitude >= 0.1f)
        {
            button++;
            print(button);
            PrimaryShoot();
        }

        timeBetween += Time.deltaTime;
        int shotsFired = (int)(timeBetween / fireRate);

        for (int i = 0; i < shotsFired; ++i)
        {
            PrimaryShoot();
        }
        if (shotsFired > 0)
        {
            GetComponent<AudioSource>().PlayOneShot(ShotSound, 1F);
        }

        timeBetween %= fireRate;*/
    }
    void PrimaryShoot()
    {
        if (shoot)
        {
            if (WorldMap == false)
            {
                if (p2)
                {
                    if (scores.pCount2 == 2)
                    {
                        Shoot(Bullet2P2, PrimaryOffsetX, PrimaryOffsetY, false, holdTimeP2, transform.rotation.z);
                    }
                    if(scores.pCount2 == 1)
                    {
                        Shoot(BulletP2, PrimaryOffsetX, PrimaryOffsetY, false, holdTimeP2, transform.rotation.z);
                    }
                    if (scores.pCount2 == 3)
                    {
                        Shoot(Bullet3P2, PrimaryOffsetX, PrimaryOffsetY, false, holdTimeP2, transform.rotation.z);
                    }
                    if (scores.pCount2 >= 4)
                    {
                        Shoot(Bullet4P2, PrimaryOffsetX, PrimaryOffsetY, false, holdTime, 0.1f);
                        Shoot(Bullet4P2, PrimaryOffsetX, PrimaryOffsetY, false, holdTime, transform.rotation.z);
                        Shoot(Bullet4P2, PrimaryOffsetX, PrimaryOffsetY, false, holdTime, -0.1f);
                    }
                }
                else
                {
                    if (scores.pCount == 2)
                    {
                        Shoot(Bullet2, PrimaryOffsetX, PrimaryOffsetY, false, holdTime, transform.rotation.z);
                    }
                    if (scores.pCount == 1)
                    {
                        Shoot(Bullet, PrimaryOffsetX, PrimaryOffsetY, false, holdTime, transform.rotation.z);
                    }
                    if (scores.pCount == 3)
                    {
                        Shoot(Bullet3, PrimaryOffsetX, PrimaryOffsetY, false, holdTime, transform.rotation.z);
                    }
                    if (scores.pCount >= 4)
                    {
                        Shoot(Bullet4, PrimaryOffsetX, PrimaryOffsetY, false, holdTime, 0.1f);
                        Shoot(Bullet4, PrimaryOffsetX, PrimaryOffsetY, false, holdTime, transform.rotation.z);
                        Shoot(Bullet4, PrimaryOffsetX, PrimaryOffsetY, false, holdTime, -0.1f);
                    }
                }
            }

            else if (WorldMap == true)
            {
                Shoot(Bullet, PrimaryOffsetX, PrimaryOffsetY, false, holdTime, transform.rotation.z);
            }
        }
    }
    void SecondaryShoot()
    {
        if (WorldMap == false)
        {
            if (p2)
            {
                if (scores.sCount2 > 0)
                {
                    Shoot(BombP2, SecondaryOffsetX, SecondaryOffsetY, true, holdTimeP2, transform.rotation.z);
                    holdTimeP2 = 4f;
                    scores.sCount2--;
                }
            }
            else
            {
                if (scores.sCount > 0)
                {
                    Shoot(Bomb, SecondaryOffsetX, SecondaryOffsetY, true, holdTime, transform.rotation.z);
                    holdTime = 4f;
                    scores.sCount--;
                }
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