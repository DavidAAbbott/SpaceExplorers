using UnityEngine;
using System.Collections;

public class PlayerMain : MonoBehaviour
{
    public GameObject explosion, healthPoint;
    public Vector2 leftStick = new Vector2(0, 0);
    public float ThrustForce, ThrustMax, BoostForce, RotationSpeed;
    public float radialDeadZone = 0.25f;
    private float horizontal, ThrustMin;
    private float vertical = 0f;
    private float KBvertical = 0f;
    private SpriteRenderer spr;
    public Color32 green, yellow, orange, red;

    public int health = 100;
    public static bool KBControls = false;
    public static bool first = true;

    void Start()
    {
        spr = healthPoint.GetComponent<SpriteRenderer>();
        ThrustMin = ThrustForce;
        if (!first)
        {
            gameObject.transform.position = EnterPlanet.prevLoc;
        }
    }

    void Update()
    {
        if (health > 70)
        {
            spr.color = green;
        }
        else if (health <= 70 && health > 30)
        {
            spr.color = yellow;
        }
        else if (health <= 30 && health > 10)
        {
            spr.color = orange;
        }
        else if (health <= 10 && health > 0)
        {
            spr.color = red;
        }
        else
        {
            StartCoroutine("PlayerDeath");
        }
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            KBControls = !KBControls;
        }
        if (KBControls == false)
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
        gameObject.SetActive(false);
        Instantiate(explosion, transform.position, new Quaternion());
        yield return new WaitForSeconds(3);
        Application.LoadLevel(1);
    }

    void OnTriggerEnter2D(Collider2D collider)
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