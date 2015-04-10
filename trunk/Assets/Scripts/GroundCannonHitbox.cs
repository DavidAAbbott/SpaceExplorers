using UnityEngine;
using System.Collections;

public class GroundCannonHitbox : MonoBehaviour {
    public static int cannonHP = 10;
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
        if (collider.tag == "p1Bullet" || collider.tag == "p2Bullet")
        {
            cannonHP -= Projectile.bullet1Dmg;
        }
        if (collider.tag == "p1Bullet3" || collider.tag == "p2Bullet2")
        {
            cannonHP -= Projectile.bullet2Dmg;
        }
        if (collider.tag == "p1Bullet3" || collider.tag == "p2Bullet3")
        {
            cannonHP -= Projectile.bullet3Dmg;
        }
        if (collider.tag == "p1Bomb" || collider.tag == "p2Bomb")
        {
            cannonHP -= Projectile.bombDmg;
        }
    }
}
