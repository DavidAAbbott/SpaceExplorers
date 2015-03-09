using UnityEngine;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour
{
    public GameObject explosion;
    public Vector2 leftStick = new Vector2(0, 0);
    public float ThrustForce,angularVelocity;
    public float radialDeadZone = 0.25f;
    private float horizontal, vertical, KBvertical;
    public int health;
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

    void UpdatePlayerRotation()
    {
        Vector3 direction = new Vector3(leftStick.x, -leftStick.y, 0);
        if (direction.magnitude > radialDeadZone)
        {
            Quaternion currentRotation = Quaternion.LookRotation(Vector3.forward, direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, currentRotation, Time.deltaTime * angularVelocity);           
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