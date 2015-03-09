using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public GameObject explosion;
    public Vector2 leftStick = new Vector2(0, 0);
    public float ThrustForce, ThrustMin, ThrustMax, BoostForce, RotationSpeed;
    public float radialDeadZone = 0.25f;
    private float horizontal, vertical, KBvertical;
    private bool onoff;
    public static bool KBcontrols = false;
  


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
      
        UpdatePlayerRotation();

        //Death
        if (health <= 0)
        {
            Destroy(gameObject);
            Instantiate(explosion, transform.position, new Quaternion());
        }
    }

    void FixedUpdate()
    {
        leftStick = new Vector2(Input.GetAxis("L_XAxis_1"), Input.GetAxis("L_YAxis_1"));

        //Vector2 input = new Vector2(Input.GetAxis("TriggersR_1"), Input.GetAxis("TriggersR_1"));

        if (Input.GetButtonDown("X_1") && ThrustForce < ThrustMax)
        {
            ThrustForce += BoostForce;
        }

        else if (Input.GetButtonUp("X_1") && ThrustForce > ThrustMin)
        {
            ThrustForce -= BoostForce;
        }

        Movement();
    }

    void Movement()
    {
        if(KBcontrols == false)
        {
            vertical = Input.GetAxis("TriggersL_1");
            rigidbody2D.AddForce(transform.up * vertical * ThrustForce * Time.deltaTime);
        }
        else
        {
            KBvertical = Input.GetAxis("MapMovement");
            rigidbody2D.AddForce(transform.up * KBvertical * ThrustForce * Time.deltaTime);
        }

    }

        if (direction.magnitude > radialDeadZone)
        {
            Quaternion currentRotation = Quaternion.LookRotation(Vector3.forward, direction);
            transform.rotation = Quaternion.Lerp(transform.rotation, currentRotation, Time.deltaTime * RotationSpeed);

            rigidbody2D.AddForce(direction2D * ThrustForce * Time.deltaTime);
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