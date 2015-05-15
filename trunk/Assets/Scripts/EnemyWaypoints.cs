using UnityEngine;
using System.Collections;

public class EnemyWaypoints : MonoBehaviour
{
    public Transform[] waypoints;
    private int currentWaypoint;
    private Transform waypoint;
    private bool blastoff = false;
    private bool hasPlayed = false;
    private Animator liekkiAnim, enemyAnim;
    public GameObject lieska;
    public AudioClip whoosh;
   
    public float speed = 1f;
    public float speedIncrease = 4f;
    private float timer = 0f;

    void Start(){
        liekkiAnim = lieska.GetComponent<Animator>();
        enemyAnim = gameObject.GetComponent<Animator>();
        liekkiAnim.SetBool("x-", true);
        enemyAnim.SetBool("blastoff", false);
        lieska.SetActive(false);
    }
    void Update()
    {
        Move();
        waypoint = waypoints[currentWaypoint];

        timer += Time.deltaTime;
    }
    void Move()
    {
        if(waypoint && !blastoff)
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoint.transform.position, speed * Time.deltaTime * timer * 3f);
            /*var newRotation = Quaternion.LookRotation(transform.position - waypoint.position);
            newRotation.x = 0;
            //newRotation.z = 0;
            newRotation.y = 0;
            float rotationDamp = Time.deltaTime * 15;
            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, rotationDamp);*/
        }
        if(blastoff)
        {
            enemyAnim.SetBool("blastoff", true);
            liekkiAnim.SetBool("x+", true);
            transform.Translate(-Vector2.right * (speed * speedIncrease) * Time.deltaTime);

            if(hasPlayed == false)
            {
                GetComponent<AudioSource>().PlayOneShot(whoosh);
                hasPlayed = true;
            }  
        }
        //currentSpeed = speed * Time.deltaTime;
        //transform.Translate(0, 0, Time.deltaTime * currentSpeed);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Waypoint")
        {
            liekkiAnim.SetBool("x-", false);
            blastoff = true;
            lieska.SetActive(true);

            /*if (currentWaypoint >= waypoints.Length)
            {
                currentWaypoint = 0;
            }*/
        }
    }
}
