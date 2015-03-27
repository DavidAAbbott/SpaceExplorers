using UnityEngine;
using System.Collections;

public class GroundCannonHitbox : MonoBehaviour {
    public static int cannonHP = 5;
    private BoxCollider2D box;
    public GameObject explosion;

	void Start () {
        box = GetComponent<BoxCollider2D>();
	}
	
	void Update () {
	    if(cannonHP <= 0)
        {
            Destroy(gameObject);
            Instantiate(explosion, transform.position, new Quaternion());
        }
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "pBullet" || collider.tag == "pBullet2")
        {
            cannonHP--;
        }
    }
}
