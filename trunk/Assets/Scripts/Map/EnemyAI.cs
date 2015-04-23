using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class EnemyAI : MonoBehaviour
{
    public GameObject explosion;
    public GameObject EnemyToSpawn;
    public int SpawnRange, EnemySpawn;
    public float PatrolSpeed, AttackSpeed, RotationSpeed, ShipHealth, MothershipHealth;
    public bool randSpawn, IsMothership;
    private bool patrol = true;

    private int[] TransformDirection;
    private int RandomDirectionX;
    private int RandomDirectionY;
    private int DirectionIndex;

    Transform target;
    Transform myTransform;

    void Awake()
    {
        myTransform = transform;
    }

    // Use this for initialization
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;

        if (randSpawn == true)
        {
            transform.position = Random.insideUnitCircle * SpawnRange;
        }

        if (IsMothership == false)
        {
            Rotation360();
        }

        TransformDirection = new int[] {0,1,-1};

        DirectionIndex = Random.Range(0, TransformDirection.Length);
        RandomDirectionX = TransformDirection[DirectionIndex];
        RandomDirectionY = TransformDirection[DirectionIndex];
    }

    void Update()
    {
        if (ShipHealth <= 0 && IsMothership == false)
        {
            Destroy(gameObject);
            Instantiate(explosion, transform.position, new Quaternion());
        }

        if (MothershipHealth <= 0 && IsMothership == true)
        {
            Destroy(gameObject);
            Instantiate(explosion, transform.position, new Quaternion());
        }
    }
 
    void FixedUpdate()
    {
        if (patrol == true && IsMothership == false)
        {
            transform.position -= -transform.up * PatrolSpeed * Time.deltaTime;
        }

        else if (patrol == true && IsMothership == true)
        {
            transform.position -= new Vector3(RandomDirectionX, RandomDirectionY, 0) * PatrolSpeed * Time.deltaTime;
        }

        else if (patrol == false)
        {
            Quaternion rot;

            if (IsMothership == true)
            {
                rot = Quaternion.LookRotation(target.position - myTransform.position, Vector3.up * RotationSpeed);
            }
            else
            {
                rot = Quaternion.LookRotation(target.position - myTransform.position, Vector3.forward * RotationSpeed);
            }

            myTransform.rotation = rot;

            transform.position = Vector2.MoveTowards(transform.position, target.position, AttackSpeed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Bullet" && IsMothership == false)
        {
            ShipHealth = ShipHealth - 10;
        }

        if (collider.tag == "Bullet" && IsMothership == true)
        {
            MothershipHealth = MothershipHealth - 10;
        }

        if (collider.tag == "DetectRadius" && IsMothership == false)
        {
            patrol = false;
        }

        if (collider.tag == "DetectRadius" && IsMothership == true)
        {
            patrol = false;

            for (int i = 0; i < EnemySpawn; i++)
            {
                Instantiate(EnemyToSpawn, transform.position, new Quaternion());
            }
        }

        if (collider.gameObject.tag == "Player" && IsMothership == false)
        {
            Destroy(gameObject);
            Instantiate(explosion, transform.position, new Quaternion());
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "DetectRadius")
        {
            Rotation360();
            patrol = true;
        }
    }

    void OnCollisionStay2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "WorldBoundary")
        {
            Rotation360();
        }
    }

    void Rotation360()
    {
        Vector3 euler = transform.eulerAngles;
        euler.z = 360f;
        transform.eulerAngles = euler;
    }
}