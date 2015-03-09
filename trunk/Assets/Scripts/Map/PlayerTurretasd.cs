using UnityEngine;
using System.Collections;

public class PlayerTurret : MonoBehaviour
{
    public Vector2 rightStick = new Vector2(0, 0);
    public float RotationSpeed = 12.0f;
    public float radialDeadZone = 0.25f;

    public float fireRate = 0.2f;
    private float timeBetween = 0.0f;
    public AudioClip ShotSound;
    public GameObject Bullet;

    public float x, y;

    // Update is called once per frame
    void Update()
    {
        rightStick = new Vector2(Input.GetAxis("R_XAxis_1"), Input.GetAxis("R_YAxis_1"));
        UpdatePlayerRotation();

        //Vector2 inputs = new Vector2(Input.GetAxis("TriggersR_1"), Input.GetAxis("TriggersR_1"));

        if (rightStick.sqrMagnitude < 0.1f)
        {
            //Reset
            timeBetween = 0.0f;
            return;
        }

        timeBetween += Time.deltaTime;
        int shotsFired = (int)(timeBetween / fireRate);

        for (int i = 0; i < shotsFired; ++i)
        {
            Shoot();
        }

        if (shotsFired > 0)
        {
            audio.PlayOneShot(ShotSound, 1F);
        }

        timeBetween %= fireRate;
    }
    void UpdatePlayerRotation()
    {
        var direction = new Vector3(rightStick.x, rightStick.y, 0);
        if (direction.magnitude > radialDeadZone)
        {
            var currentRotation = Quaternion.LookRotation(Vector3.forward, direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, currentRotation, Time.deltaTime * RotationSpeed);
        }
    }
    void Shoot()
    {
        GameObject pNewObject;
        pNewObject = Instantiate(Bullet) as GameObject;
        pNewObject.transform.rotation = transform.rotation;
        Vector2 pos = new Vector2(transform.position.x + x, transform.position.y + y);
        pNewObject.transform.position = pos;
    }
}
