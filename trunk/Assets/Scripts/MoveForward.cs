using UnityEngine;
using System.Collections;

public class MoveForward : MonoBehaviour {
    public float speed = 2f;
    public static bool stop = false;
    public static bool back = false;
    public static bool slow = false;

	void Start () {
	    
	}
	
	void Update () {
        if (!stop)
        {
            if (!slow && !back)
            {
                transform.position += Vector3.right * speed * Time.deltaTime;
            }
            else if (slow && !back)
            {
                transform.position += (Vector3.right * speed * Time.deltaTime) / 4;
            }
            else if (!slow && back)
            {
                transform.position -= Vector3.right * speed * Time.deltaTime;
            }
            else if (slow && back)
            {
                transform.position -= (Vector3.right * speed * Time.deltaTime) / 4;
            }
        }
	}
}
