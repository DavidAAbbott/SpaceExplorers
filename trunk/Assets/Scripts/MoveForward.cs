using UnityEngine;
using System.Collections;

public class MoveForward : MonoBehaviour {
    public float speed = 2f;
    public static bool stop = false;
    public GameObject slowtrigger;

	void Start () {
	    
	}
	
	void Update () {
        if (!stop)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        else
        {
            StartCoroutine("slowdown");
        }
	}
    IEnumerator slowdown()
    {
        transform.position += Vector3.right * speed * -Time.deltaTime;
        yield return new WaitForSeconds(0.3f);
        transform.position = transform.position;
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "SlowTrigger")
        {
            stop = true;
        }
    }
}
