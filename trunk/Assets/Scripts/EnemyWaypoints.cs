using UnityEngine;
using System.Collections;

public class EnemyWaypoints : MonoBehaviour
{
    public Transform[] waypoints;
    private int currentWaypoint;
    private Transform waypoint;

    public float speed = 1f;
    private float currentSpeed = 0f;

    void Start(){
    }
    void Update()
    {
        Move();
        waypoint = waypoints[currentWaypoint];
    }
    void Move()
    {
        if (waypoint) //if waypoint exists
        {
            //var newRotation = transform.LookAt(waypoint.position, Vector3.up);
            var newRotation = Quaternion.LookRotation(transform.position - waypoint.position);
            newRotation.x = 0;
            //newRotation.z = 0;
            newRotation.y = 0;
            float rotationDamp = Time.deltaTime * 15;
            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, rotationDamp);
        }
        currentSpeed = speed * Time.deltaTime;
        transform.Translate(0, 0, Time.deltaTime * currentSpeed);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Waypoint")
        {
            currentWaypoint++;

            if (currentWaypoint >= waypoints.Length)
            {
                currentWaypoint = 0;
            }
        }
    }
}
