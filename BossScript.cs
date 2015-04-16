using UnityEngine;
using System.Collections;

public class BossScript : MonoBehaviour {
    private float angle = 0;
    public float seconds = 5;
    public float bulletSpeed = 0.2f;
    private float speed; //2*PI in degress is 360, so you get 5 seconds to complete a circle
    public float radius = 2;
    private Vector2 pos = Vector2.zero;
    private Vector2 origpos = Vector2.zero;
    public float BulletSpawnX = 1f;
    public float BulletSpawnY = 1f;
    public GameObject bomb;
    public GameObject explosion;
    public int bossHP = 20;
    private BoxCollider2D box;

	void Start () {
        StartCoroutine("Pattern");
        origpos = transform.position;
        speed = (2 * Mathf.PI) / seconds;
        box = GetComponent<BoxCollider2D>();
        box.enabled = false;
	}
	
	void Update () {
	    angle += speed*Time.deltaTime;
        pos.x = Mathf.Cos(angle)*radius + origpos.x;
        pos.y = Mathf.Sin(angle)*radius + origpos.y;

        transform.position = pos;

        if (bossHP <= 0)
        {
            Destroy(gameObject);
            Instantiate(explosion, transform.position, new Quaternion());
            MoveForward.stop = false;
            BackgroundScroll.moving = true;
        }

        if(ShieldHitBox.shieldHP <= 0)
        {
            box.enabled = true;
        }
	}
    void Shoot(float pitch)
    {
        GameObject pNewObject;
        pNewObject = Instantiate(bomb) as GameObject;
        pNewObject.transform.rotation = transform.rotation;
        Vector2 pos = transform.position;
        pos.x += BulletSpawnX;
        pos.y += BulletSpawnY;
        pNewObject.transform.position = pos;
        pNewObject.GetComponent<Rigidbody2D>().velocity = new Vector2(18f, -16f) * -bulletSpeed / pitch;
    }
    IEnumerator Pattern()
    {
        yield return null;
        while (true)
        {
            yield return new WaitForSeconds(2f);
            Shoot(1.1f);
            yield return new WaitForSeconds(0.7f);
            Shoot(0.8f);
            yield return new WaitForSeconds(0.7f);
            Shoot(0.7f);
            yield return new WaitForSeconds(1.2f);
        }
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "p1Bullet" || collider.tag == "p2Bullet")
        {
            bossHP -= Projectile.bullet1Dmg;
        }
        if (collider.tag == "p1Bullet3" || collider.tag == "p2Bullet2")
        {
            bossHP -= Projectile.bullet2Dmg;
        }
        if (collider.tag == "p1Bullet3" || collider.tag == "p2Bullet3")
        {
            bossHP -= Projectile.bullet3Dmg;
        }
        if (collider.tag == "p1Bomb" || collider.tag == "p2Bomb")
        {
            bossHP -= Projectile.bombDmg;
        }
    }
}
