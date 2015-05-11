using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class EnemyAI : MonoBehaviour
{
    public GameObject explosion;
    public GameObject EnemyBullet;
    public GameObject EnemyToSpawn;
    public GameObject EnemyToSpawn2;

    public int spawnRange, enemySpawnCount, enemySpawnCount2;
    public float patrolSpeed, attackSpeed, rotationSpeed, fireRate, waitTime, mothershipHealth;

    public bool randSpawn, IsMothership;
    private bool patrol = true;

    private int[] TransformDirection;
    private int RandomDirectionX;
    private int RandomDirectionY;
    private int DirectionIndex;

    Transform target;
    Transform myTransform;
    Quaternion rot;

    void Awake()
    {
        myTransform = transform;
        target = GameObject.FindWithTag("Player").transform;
    }

    void Start()
    {
        //Spawn code for motherships
        if (randSpawn == true)
        {
            transform.position = Random.insideUnitCircle * spawnRange;
        }

        //Used for fighter ship patrol movement
        if (IsMothership == false)
        {
            Rotation360();
        }

        //Used for mothership patrol movement
        GenerateDirection();
    }

    void FixedUpdate()
    {
        //Fighter ship patrol movement
        if (patrol == true && IsMothership == false)
        {
            transform.position -= -transform.up * patrolSpeed * Time.deltaTime;
        }

        //Mothership patrol movement
        else if (patrol == true && IsMothership == true)
        {
            if (RandomDirectionX == 0 && RandomDirectionY == 0)
            {
                GenerateDirection();
            }
            else
            {
                transform.position -= new Vector3(RandomDirectionX, RandomDirectionY, 0) * patrolSpeed * Time.deltaTime;
            }
        }

        //Enemy moves to attack player
        else if (patrol == false)
        {
            if (IsMothership == true)
            {
                rot = Quaternion.LookRotation(target.position - myTransform.position, Vector3.up * rotationSpeed);
            }
            else
            {
                rot = Quaternion.LookRotation(target.position - myTransform.position, Vector3.forward * rotationSpeed);
            }

            myTransform.rotation = rot;
            transform.position = Vector2.MoveTowards(transform.position, target.position, attackSpeed * Time.deltaTime);
        }
    }

    //Fire at player
    void Fire()
    {
        Instantiate(EnemyBullet, myTransform.position + (target.position - myTransform.position).normalized, rot);
    }

    //Check for bullet collision and death
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "p1Bullet" && IsMothership == true)
        {
            mothershipHealth = mothershipHealth - 1;

            if (mothershipHealth <= 0 && IsMothership == true)
            {
                Destroy(gameObject);
                Instantiate(explosion, transform.position, new Quaternion());
            }
        }

        if (collider.tag == "p1Bullet" && IsMothership == false)
        {
            Destroy(gameObject);
            Instantiate(explosion, transform.position, new Quaternion());
        }

        //If enemy enters the aggro range of the player: end patrol and start firing
        if (collider.tag == "DetectRadius" && IsMothership == false)
        {
            patrol = false;
            StartCoroutine(Firing());
        }

        if (collider.tag == "DetectRadius" && IsMothership == true)
        {
            patrol = false;

            for (int i = 0; i < enemySpawnCount; i++)
            {
                Instantiate(EnemyToSpawn, transform.position, new Quaternion());
            }

            for (int i = 0; i < enemySpawnCount2; i++)
            {
                Instantiate(EnemyToSpawn2, transform.position, new Quaternion());
            }
        }

        //If fighter ship hits player destroy it
        if (collider.gameObject.tag == "Player" && IsMothership == false)
        {
            Destroy(gameObject);
            Instantiate(explosion, transform.position, new Quaternion());
        }
    }

    //When enemy leaves aggro range, return to patrolling
    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "DetectRadius")
        {
            Rotation360();
            patrol = true;
        }
    }

    //When enemy hits the border of the map, randomize rotation in different direction
    void OnCollisionStay2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "WorldBoundary" && IsMothership == true)
        {
            GenerateDirection();
        }

        if (collider.gameObject.tag == "WorldBoundary" && IsMothership == false)
        {
            Rotation360();
        }
    }

    //Randomizes rotation of enemy fighters
    void Rotation360()
    {
        Vector3 euler = transform.eulerAngles;
        euler.z = 360f;
        transform.eulerAngles = euler;
    }

    //Used to generate direction for mothership patrol movement
    void GenerateDirection()
    {
        TransformDirection = new int[] { 0, 1, -1 };
        DirectionIndex = Random.Range(0, TransformDirection.Length);
        RandomDirectionX = TransformDirection[DirectionIndex];

        DirectionIndex = Random.Range(0, TransformDirection.Length);
        RandomDirectionY = TransformDirection[DirectionIndex];
    }

    //Coroutine for firerate
    IEnumerator Firing()
    {
        yield return new WaitForSeconds(waitTime);
        while (patrol == false)
        {
            Fire();
            yield return new WaitForSeconds(fireRate);
        }
    }
}