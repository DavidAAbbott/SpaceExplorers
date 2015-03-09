using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public GameObject explosion;
    public Vector2 leftStick = new Vector2(0, 0);
    public float ThrustForce, ThrustMax, BoostForce, RotationSpeed;
    public float radialDeadZone = 0.25f;
    private float horizontal, vertical, KBvertical, ThrustMin;
    public int health = 100;
    public static bool KBcontrols = false;

    void Start()
    {
        ThrustMin = ThrustForce;
    }

    void Update()
    {
        if (KBcontrols == false)
        {
            leftStick = new Vector2(Input.GetAxis("L_XAxis_1"), Input.GetAxis("L_YAxis_1"));
        }
        else
        {
            leftStick = new Vector2(Input.GetAxis("MapHorizontal"), Input.GetAxis("MapVertical"));
        }

        //Boost
        if (Input.GetButtonDown("X_1") && ThrustForce < ThrustMax)
        {
            ThrustForce += BoostForce;
        }

        else if (Input.GetButtonUp("X_1") && ThrustForce > ThrustMin)
        {
            ThrustForce -= BoostForce;
        }

        //Death
        if (health <= 0)
        {
            Destroy(gameObject);
            Instantiate(explosion, transform.position, new Quaternion());
        }
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

            if (KBcontrols == false)
            {
                vertical = Input.GetAxis("L_YAxis_1");
                rigidbody2D.AddForce(direction2D * ThrustForce * Time.deltaTime);
            }
            else if (KBcontrols == true)
            {
                KBvertical = Input.GetAxis("MapMovement");
                rigidbody2D.AddForce(transform.up * KBvertical * ThrustForce * Time.deltaTime);
            }
        }
    }

    void OnCollisionStay2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Enemy")
        {
            health = health - 10;
        }
    }
}