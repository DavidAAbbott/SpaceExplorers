using UnityEngine;
using System.Collections;

public class ShieldHitBox : MonoBehaviour {
    public static int shieldHP = 20;
    private CircleCollider2D box;

	void Start () {
        box = GetComponent<CircleCollider2D>();
	}
	
	void Update () {
	    if(shieldHP <= 0)
        {
            Destroy(gameObject);
        }
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "pBullet" || collider.tag == "pBullet2")
        {
            shieldHP--;
        }
    }
}
