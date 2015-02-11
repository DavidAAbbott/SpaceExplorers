using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour {
	void Start () {
	
	}
	
	void Update () {
	    
	}
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "Boundary")
        {
            Destroy(gameObject);
        }
    }
}
