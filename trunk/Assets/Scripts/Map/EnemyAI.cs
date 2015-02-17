using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour
{
    public GameObject explosion;
    public int SpawnRange;
    public float PatrolSpeed;
    public float AttackSpeed;
    public float RotationSpeed;
    public bool randSpawn;
    private bool patrol = true;

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

        if (randSpawn)
        {
            transform.position = Random.insideUnitCircle * SpawnRange;
        }

        RandomRotation();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (patrol == true)
        {
            transform.position -= -transform.up * PatrolSpeed * Time.deltaTime;
        }
        else if (patrol == false)
        {
            Quaternion rot = Quaternion.LookRotation(target.position - myTransform.position, Vector3.forward * RotationSpeed);
            myTransform.rotation = rot;

            transform.position = Vector2.MoveTowards(transform.position, target.position, AttackSpeed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Bullet")
        {
            Destroy(gameObject);
            Instantiate(explosion, transform.position, new Quaternion());
        }

        if (collider.tag == "DetectRadius")
        {
            patrol = false;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "DetectRadius")
        {
            RandomRotation();
            patrol = true;
        }
    }

    void OnCollisionStay2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Boundary")
        {
            RandomRotation();
        }
    }

    void RandomRotation()
    {
        Vector3 euler = transform.eulerAngles;
        euler.z = Random.Range(0f, 360f);
        transform.eulerAngles = euler;
    }
}