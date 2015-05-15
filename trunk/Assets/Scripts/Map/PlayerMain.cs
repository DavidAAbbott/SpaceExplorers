using UnityEngine;
using System.Collections;

public class PlayerMain : MonoBehaviour
{
    public GameObject explosion;
    public Vector2 leftStick = new Vector2(0, 0);
    public float ThrustForce, ThrustMax, BoostForce, RotationSpeed;
    public float radialDeadZone = 0.25f;
    private float horizontal, ThrustMin;
    private float vertical = 0f;
    private float KBvertical = 0f;

    public int health = 100;
    public static bool KBControls = false;
    public bool KBControlsEditor = false;

    void Start()
    {
        ThrustMin = ThrustForce;

        if (KBControlsEditor == false)
        {
            KBControls = false;
        }
        else
        {
            KBControls = true;
        }
    }

    void Update()
    {
        if (KBControls == false)
        {
            leftStick = new Vector2(Input.GetAxis("L_XAxis_1"), Input.GetAxis("L_YAxis_1"));
        }
        else
        {
            leftStick = new Vector2(Input.GetAxis("MapHorizontal"), Input.GetAxis("MapVertical"));
        }

        //Boost
        if (KBControls == false)
        {
            if (Input.GetButtonDown("X_1") && ThrustForce < ThrustMax)
            {
                ThrustForce += BoostForce;
            }

            else if (Input.GetButtonUp("X_1") && ThrustForce > ThrustMin)
            {
                ThrustForce -= BoostForce;
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.LeftShift) && ThrustForce < ThrustMax)
            {
                ThrustForce += BoostForce;
            }

            else if (Input.GetKey(KeyCode.LeftShift) && ThrustForce > ThrustMin)
            {
                ThrustForce -= BoostForce;
            }
        }

        //PlayerDeath();
    }

    void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        Vector3 direction = new Vector3(leftStick.x, -leftStick.y, 0);
        Vector2 direction2D = new Vector2(direction.x, direction.y);
        direction2D.x = transform.up.x;
        direction2D.y = transform.up.y;

        if (direction.magnitude > radialDeadZone)
        {
            Quaternion currentRotation = Quaternion.LookRotation(Vector3.forward, direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, currentRotation, Time.deltaTime * RotationSpeed);

            if (KBControls == false)
            {
                vertical = Input.GetAxis("L_YAxis_1");
                GetComponent<Rigidbody2D>().AddForce(direction2D * ThrustForce * Time.deltaTime);
            }
            else if (KBControls == true)
            {
                KBvertical = Input.GetAxis("MapMovement");
                GetComponent<Rigidbody2D>().AddForce(direction2D * ThrustForce * Time.deltaTime);
            }
        }
    }

    IEnumerator PlayerDeath()
    {
        if (health <= 0)
        {
            gameObject.SetActive(false);
            Instantiate(explosion, transform.position, new Quaternion());
            yield return new WaitForSeconds(3);
            Application.LoadLevel(1);
        }
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Enemy")
        {
            health = health - 10;
        }

        if (collider.gameObject.tag == "Bullet")
        {
            health = health - 5;
        }
    }
}