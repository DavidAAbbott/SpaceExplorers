using UnityEngine;
using System.Collections;

public class PlayerTurretShot : MonoBehaviour
{
    public Vector2 rightStick = new Vector2(0, 0);
    public float angularVelocity = 12.0f;
    public float radialDeadZone = 0.25f;

    public float fireRate = 0.2f;
    private float timeBetween = 0.0f;

    public static bool KBControls = false;
    public bool KBControlsEditor = false;

    public float smooth = 2.0f;

    public AudioClip ShotSound;
    public GameObject Bullet;
    Vector2 direction2D = Vector2.zero;

    void Start()
    {
        /*
        if (KBControlsEditor == false)
        {
            KBControls = false;
        }
        else
        {
            KBControls = true;
        }*/
    }

    void Update()
    {
        if (KBControls == false)
        {
            if (MainMenu.player2 == false)
            {
                rightStick = new Vector2(Input.GetAxis("R_XAxis_1"), Input.GetAxis("R_YAxis_1"));

                UpdatePlayerRotation();

                if (rightStick.sqrMagnitude < 0.1f)
                {
                    //Reset
                    timeBetween = 0.0f;
                    return;
                }
            }
            else// if (MainMenu.player2 == true)
            {
                rightStick = new Vector2(Input.GetAxis("R_XAxis_2"), Input.GetAxis("R_YAxis_2"));

                UpdatePlayerRotation();

                if (rightStick.sqrMagnitude < 0.1f)
                {
                    //Reset
                    timeBetween = 0.0f;
                    return;
                }
            }
        }

        else //if (KBControls == true)
        {
            Vector2 inputs = Vector2.zero;

            if (Input.GetMouseButton(0))
            {
                inputs = new Vector2(Input.GetAxis("MapShoot"), Input.GetAxis("MapShoot"));
            }

            if (inputs.sqrMagnitude < 0.1f)
            {
                //Reset
                timeBetween = 0.0f;
                return;
            }
        }

        timeBetween += Time.deltaTime;
        int shotsFired = (int)(timeBetween / fireRate);

        for (int i = 0; i < shotsFired; ++i)
        {
            Shoot();
        }

        if (shotsFired > 0)
        {
            GetComponent<AudioSource>().PlayOneShot(ShotSound, 1F);
        }

        timeBetween %= fireRate;
    }
    void UpdatePlayerRotation()
    {
        Vector3 direction = new Vector3(rightStick.x, rightStick.y, 0);

        if (direction.magnitude > radialDeadZone)
        {
            var currentRotation = Quaternion.LookRotation(Vector3.forward, direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, currentRotation, Time.deltaTime * angularVelocity);
        }
    }

    void Shoot()
    {
        GameObject pNewObject;
        pNewObject = Instantiate(Bullet) as GameObject;
        pNewObject.transform.rotation = transform.rotation;
        Vector2 pos = new Vector2(transform.position.x, transform.position.y);
        pNewObject.transform.position = pos;
    }
}