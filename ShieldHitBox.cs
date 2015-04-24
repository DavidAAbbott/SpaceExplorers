using UnityEngine;
using System.Collections;

public class ShieldHitBox : MonoBehaviour {
    public static int shieldHP = 50;
    private Score scores;
    public int points = 100;

	void Start () {
        scores = GameObject.Find("Canvas").GetComponent<Score>();
	}
	
	void Update () {
	    if(shieldHP <= 0)
        {
            Destroy(gameObject);
            if (scores.cmb == true)
            {
                scores.score += points * scores.combo;
            }
            if (scores.cmb2 == true)
            {
                scores.score2 += points * scores.combo2;
            }
        }
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "p1Bullet" || collider.tag == "p1Bullet2" || collider.tag == "p1Bullet3" || collider.tag == "p1Bomb")
        {
            scores.hit++;
            scores.timer += 0.5f;
            scores.combo++;

            if (!scores.cmb)
            {
                scores.combo = 0;
                scores.score += points;
            }
        }
        if (collider.tag == "p2Bullet" || collider.tag == "p2Bullet2" || collider.tag == "p2Bullet3" || collider.tag == "p2Bomb")
        {
            scores.hit2++;
            scores.timer2 += 0.5f;
            scores.combo2++;

            if (!scores.cmb2)
            {
                scores.combo2 = 0;
                scores.score2 += points;
            }
        }
        if (collider.tag == "p1Bullet" || collider.tag == "p2Bullet")
        {
            shieldHP -= Projectile.bullet1Dmg;
        }
        if (collider.tag == "p1Bullet2" || collider.tag == "p2Bullet2")
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
