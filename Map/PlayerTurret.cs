using UnityEngine;
using System.Collections;

public class PlayerTurret : MonoBehaviour {

    public Vector2 rightStick = new Vector2(0, 0);
    public float angularVelocity = 12.0f;
    public float radialDeadZone = 0.25f;

    public static bool KBControls = false;
    public bool KBControlsEditor = false;

    public float smooth = 2.0f;

    void Update()
    {
        if (KBControls == false)
        {
            if (MainMenu.player2 == false)
            {
                rightStick = new Vector2(Input.GetAxis("R_XAxis_1"), Input.GetAxis("R_YAxis_1"));

                UpdatePlayerRotation();
            }
            else// if (MainMenu.player2 == true)
            {
                rightStick = new Vector2(Input.GetAxis("R_XAxis_2"), Input.GetAxis("R_YAxis_2"));

                UpdatePlayerRotation();
            }
        }

        else// if (KBControls == true)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Quaternion shiprotate = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, shiprotate, Time.deltaTime * smooth);
        }
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
}
