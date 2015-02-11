using UnityEngine;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour
{
    public Vector2 rightStick = new Vector2(0, 0);
    public float angularVelocity = 12.0f;
    public float radialDeadZone = 0.25f;
    private float vertical, horizontal;
    public float ThrustForce;
    public bool strafe = false;
    //private bool minimap = false;


    void Update()
    {
        rightStick = new Vector2(Input.GetAxis("R_XAxis_1"), Input.GetAxis("R_YAxis_1"));
        UpdatePlayerRotation();

        /*if (Input.GetButtonDown("A_1"))
        {
            minimap = !minimap;
            if (minimap)
            {
                camera.enabled = true;
            }
            else
            {
                camera.enabled = false;
            }
        }*/
    }
    void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        if(strafe == true)
        {
            horizontal = Input.GetAxis("L_XAxis_1");
            rigidbody2D.AddForce(transform.right * horizontal * ThrustForce * Time.deltaTime);
        }

        vertical = Input.GetAxis("L_YAxis_1");
        rigidbody2D.AddForce(-transform.up * vertical * ThrustForce * Time.deltaTime);
    }
    void UpdatePlayerRotation()
    {
        var direction = new Vector3(rightStick.x, rightStick.y, 0);
        if (direction.magnitude > radialDeadZone)
        {
            var currentRotation = Quaternion.LookRotation(Vector3.forward, direction);
            transform.rotation = Quaternion.Lerp(transform.rotation, currentRotation, Time.deltaTime * angularVelocity);
        }
    }
}