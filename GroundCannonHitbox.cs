using UnityEngine;
using System.Collections;

public class GroundCannonHitbox : MonoBehaviour {
    public int cannonHP = 10;
    public GameObject explosion;

	void Start () {
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
