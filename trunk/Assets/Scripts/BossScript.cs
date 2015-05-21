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
    private Score scores;
    public int points = 250;
    public GameObject stopTrigger;
    public static float bTime = 0f;
    public bool miniBoss = false;
    private SpriteRenderer rend;
    private Color32 origcolor;
    public static float explodeTime = 10f;
    public float explodeTime1 = 10f;
    public bool boss2 = false;

	void Start () {
        explodeTime = explodeTime1;
        StartCoroutine("Pattern");
        origpos = transform.position;
        speed = (2 * Mathf.PI) / seconds;
        box = GetComponent<BoxCollider2D>();
        box.enabled = false;
        scores = GameObject.Find("Canvas").GetComponent<Score>();
        rend = GetComponent<SpriteRenderer>();
        origcolor = rend.color;
        if(MainMenu.player2)
        {
            bossHP = bossHP * 2;
        }
	}
	
	void Update () {
        if (!boss2)
        {
            angle += speed * Time.deltaTime;
            pos.x = Mathf.Cos(angle) * radius + origpos.x;
            pos.y = Mathf.Sin(angle) * radius + origpos.y;

            transform.position = pos;
        }

        if (bossHP <= 0)
        {
            Instantiate(explosion, transform.position, new Quaternion());
            if (miniBoss)
            {
                MoveForward.stop = false;
            }
            MoveForward.slow = false;
            BackgroundScroll.moving = true;
            Destroy(stopTrigger);
            if (scores.cmb == true)
            {
                scores.score += points * scores.combo;
            }
            if (scores.cmb2 == true)
            {
                scores.score2 += points * scores.combo2;
            }
            if(!miniBoss)
            {
                Pause.explode = true;
            }
            Destroy(gameObject, explodeTime);
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
            if (!miniBoss)
            {
                //yield return new WaitForSeconds(2f);
                Shoot(0.5f);
                bTime = 1.8f;
                yield return new WaitForSeconds(0.7f);
                Shoot(0.61f);
                bTime = 1.5f;
                yield return new WaitForSeconds(0.7f);
                Shoot(0.9f);
                bTime = 1.2f;
                yield return new WaitForSeconds(0.7f);
                Shoot(0.3f);
                bTime = 1.7f;
                yield return new WaitForSeconds(0.7f);
                Shoot(0.42f);
                bTime = 1.7f;
                yield return new WaitForSeconds(0.9f);

                Shoot(0.7f);
                bTime = 1.2f;
                yield return new WaitForSeconds(0.7f);
                Shoot(0.56f);
                bTime = 1.4f;
                yield return new WaitForSeconds(0.7f);
                Shoot(0.48f);
                bTime = 1.7f;
                yield return new WaitForSeconds(0.7f);
                Shoot(0.3f);
                bTime = 1.7f;
                yield return new WaitForSeconds(0.7f);
                Shoot(0.42f);
                bTime = 1.7f;
                yield return new WaitForSeconds(1.1f);
            }

            if (miniBoss)
            {
                Shoot(0.5f);
                bTime = 1.8f;
                yield return new WaitForSeconds(0.5f);
                Shoot(0.61f);
                bTime = 1.5f;
                yield return new WaitForSeconds(0.5f);
                Shoot(0.9f);
                bTime = 1.2f;
                yield return new WaitForSeconds(0.5f);
                Shoot(0.42f);
                bTime = 1.7f;
                yield return new WaitForSeconds(0.7f);

                Shoot(0.7f);
                bTime = 1.2f;
                yield return new WaitForSeconds(0.5f);
                Shoot(0.56f);
                bTime = 1.4f;
                yield return new WaitForSeconds(0.5f);
                Shoot(0.48f);
                bTime = 1.7f;
                yield return new WaitForSeconds(0.5f);
                Shoot(0.42f);
                bTime = 1.7f;
                yield return new WaitForSeconds(0.9f);
            }
        }
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "p1Bullet" || collider.tag == "p1Bullet2" || collider.tag == "p1Bullet3" || collider.tag == "p1Bomb")
        {
            scores.hit++;
            scores.timer = scores.cTime;
            scores.combo++;

            if(scores.cmb == false)
            {
                scores.combo = 0;
                scores.score += points;
            }
        }
        if (collider.tag == "p2Bullet" || collider.tag == "p2Bullet2" || collider.tag == "p2Bullet3" || collider.tag == "p2Bomb")
        {
            scores.hit2++;
            scores.timer2 = scores.cTime;
            scores.combo2++;

            if (scores.cmb2 == false)
            {
                scores.combo2 = 0;
                scores.score2 += points;
            }
        }
        if (collider.tag == "p1Bullet" || collider.tag == "p2Bullet")
        {
            bossHP -= Projectile.bullet1Dmg;
            StartCoroutine("flash", 0);
            //rend.color = new Color32(255, 117, 152, 255);
        }
        if (collider.tag == "p1Bullet2" || collider.tag == "p2Bullet2")
        {
            bossHP -= Projectile.bullet2Dmg;
            StartCoroutine("flash", 0);
        }
        if (collider.tag == "p1Bullet3" || collider.tag == "p2Bullet3")
        {
            bossHP -= Projectile.bullet3Dmg;
            StartCoroutine("flash", 0);
        }
        if (collider.tag == "p1Bomb" || collider.tag == "p2Bomb")
        {
            bossHP -= Projectile.bombDmg;
            StartCoroutine("flash", 0);
        }
    }
    IEnumerator flash()
    {
        rend.color = new Color32(255, 117, 152, 255);
        yield return new WaitForSeconds(0.1f);
        rend.color = origcolor;
    }
}
