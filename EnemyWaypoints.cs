using UnityEngine;
using System.Collections;

public class EnemyWaypoints : MonoBehaviour {
    public Transform[] waypoints;
    private int currentWaypoint;
    private Transform waypoint;

    public float accelAmount = 1f;
    public float inertia = 1f;
    public float speedLimit = 10f;
    public float minSpeed = 1f;
    public float stopTime = 1f;

    private int state = 0;
    private float currentSpeed = 0f;
    private bool accel;
    private bool slow;

    public float rotationDamp = 6f;
    private bool smoothRotation = true;

	void Start () {
        state = 0;
	}
	void Update () {
        if (state == 0)
        {
            Accel();
        }
        if (state == 1)
        {
            Slow();
        }
        waypoint = waypoints[currentWaypoint];
	}
    void Accel()
    {
        if (accel == false) 
        {                   
            accel = true;
            slow = false;
        }
        if (waypoint) //if waypoint exists
        {
            if (smoothRotation)
            {
                var newRotation = Quaternion.LookRotation(transform.position - waypoint.position, Vector3.up);
                newRotation.x = 0;
                //newRotation.z = 0;
                newRotation.y = 0;
                rotationDamp = Time.deltaTime * 15;
                transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, rotationDamp);
            }
        }
        currentSpeed = currentSpeed + accelAmount * accelAmount;
        transform.Translate(0, 0, Time.deltaTime * currentSpeed);

        if (currentSpeed >= speedLimit)
        {
            currentSpeed = speedLimit;
        }
    }

    void OnTriggerEnter() //waypoint hit
    {
        state = 1; 
        currentWaypoint++;

        if (currentWaypoint >= waypoints.Length)
        {
            currentWaypoint = 0; 
        }
    }
    IEnumerator Slow ()
    {
        if (slow == false) 
        {                  
            accel = false; 
            slow = true;   
        }                  
   
        currentSpeed = currentSpeed * inertia;
        transform.Translate (0,0,Time.deltaTime * currentSpeed);
   
        if (currentSpeed <= minSpeed)
        {
            currentSpeed = 0f;
            yield return new WaitForSeconds(stopTime); 
            state = 0;
        }
    }
}
