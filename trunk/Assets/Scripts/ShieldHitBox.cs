using UnityEngine;
using System.Collections;

public class ShieldHitBox : MonoBehaviour {
    public static int shieldHP = 50;
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
        if (collider.tag == "p1Bullet" || collider.tag == "p2Bullet")
        {
            shieldHP -= Projectile.bullet1Dmg;
        }
        if (collider.tag == "p1Bullet3" || collider.tag == "p2Bullet2")
        {
            shieldHP -= Projectile.bullet2Dmg;
        }
        if (collider.tag == "p1Bullet3" || collider.tag == "p2Bullet3")
        {
            shieldHP -= Projectile.bullet3Dmg;
        }
        if (collider.tag == "p1Bomb" || collider.tag == "p2Bomb")
        {
            shieldHP -= Projectile.bombDmg;
        }
    }
}
