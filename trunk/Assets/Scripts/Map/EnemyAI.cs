using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class EnemyAI : MonoBehaviour
{
    public GameObject explosion, EnemyBullet, EnemyToSpawn, EnemyToSpawn2;

    public int spawnRange, enemySpawnCount, enemySpawnCount2;
    public float enemySpawnInterval, enemySpawnInterval2, patrolSpeed, attackSpeed, rotationSpeed, fireRate, waitTime, mothershipHealth;

    public bool randSpawn, IsMothership;
    private bool patrol = true;
    private bool JustSpawned = true;
    private bool started, started2;

    private int[] TransformDirection;
    private int RandomDirectionX, RandomDirectionY, DirectionIndex;
    private GameObject player;

    Transform target;
    Transform myTransform;
    Quaternion rot;

    void Awake()
    {
        myTransform = transform;
        player = GameObject.Find("Player");
        target = player.transform;
    }

    void Start()
    {
        //Spawn code for motherships
        if (randSpawn == true)
        {
            transform.position = Random.insideUnitCircle * spawnRange;
            StartCoroutine(Counter());
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
        else if (patrol == false && target != null)
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
        int rng = Random.Range(0,8);
        float rng2 = Random.Range(0.5f, 1f);
        if(rng == 1)
        {
            Instantiate(EnemyBullet, myTransform.position + (new Vector3(target.position.x - rng2, target.position.y, target.position.z) - myTransform.position).normalized, rot);
        }
        if (rng == 2)
        {
            Instantiate(EnemyBullet, myTransform.position + (new Vector3(target.position.x + rng2, target.position.y, target.position.z) - myTransform.position).normalized, rot);
        }
        if (rng == 3)
        {
            Instantiate(EnemyBullet, myTransform.position + (new Vector3(target.position.x + rng2, target.position.y - rng2, target.position.z) - myTransform.position).normalized, rot);
        }
        if (rng == 4)
        {
            Instantiate(EnemyBullet, myTransform.position + (new Vector3(target.position.x - rng2, target.position.y + rng2, target.position.z) - myTransform.position).normalized, rot);
        }
        if (rng == 5)
        {
            Instantiate(EnemyBullet, myTransform.position + (new Vector3(target.position.x, target.position.y - rng2, target.position.z) - myTransform.position).normalized, rot);
        }
        if (rng == 6)
        {
            Instantiate(EnemyBullet, myTransform.position + (new Vector3(target.position.x, target.position.y + rng2, target.position.z) - myTransform.position).normalized, rot);
        }
        
        if (rng == 7)
        {
            Instantiate(EnemyBullet, myTransform.position + (target.position - myTransform.position).normalized, rot);
        }
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

        if (collider.tag == "DetectRadius" && IsMothership == true && JustSpawned == false)
        {
            patrol = false;

            if (started == false)
            {
                StartCoroutine(EnemySpawn());
            }

            if (started2 == false)
            {
                StartCoroutine(EnemySpawn2());
            }
        }

        // If mothership has just spawned next to player destroy it
        if (collider.tag == "DetectRadius" && IsMothership == true && JustSpawned == true)
        {
            Destroy(gameObject);
        }

        //If fighter ship hits player destroy it
        if (collider.gameObject.tag == "Player" && IsMothership == false || collider.tag == "Asteroid" && !IsMothership)
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

    IEnumerator Counter()
    {
        yield return new WaitForSeconds(1);
        JustSpawned = false;
    }

    IEnumerator EnemySpawn()
    {
        started = true;
        int i = 0;

        while (enemySpawnCount > i)
        {
            yield return new WaitForSeconds(enemySpawnInterval);
            Instantiate(EnemyToSpawn, transform.position, new Quaternion());
            i++;
        }

        started = false;
    }

    IEnumerator EnemySpawn2()
    {
        started2 = true;
        int i = 0;

        while (enemySpawnCount2 > i)
        {
            yield return new WaitForSeconds(enemySpawnInterval2);

            Instantiate(EnemyToSpawn2, transform.position, new Quaternion());
            i++;
        }

        started2 = false;
    }
    void Update()
    {
        if(target == null)
        {
            patrol = true;
        }
    }
}