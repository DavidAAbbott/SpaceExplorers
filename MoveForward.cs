using UnityEngine;
using System.Collections;

public class MoveForward : MonoBehaviour {
    public float speed = 2f;
    public static bool stop = false;

	void Start () {
	    
	}
	
	void Update () {
        if (!stop)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        else
        {
            transform.position += (Vector3.right * speed * Time.deltaTime) / 4;
        }
	}
}
