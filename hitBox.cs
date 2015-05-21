using UnityEngine;
using System.Collections;

public class hitBox : MonoBehaviour
{
    private BoxCollider2D box;
    private SpriteRenderer sprite;
    public GameObject player;
    public GameObject lieskat;
    private Vector2 spwn;
    private Score scores;
    public bool p2 = false;
    public GameObject explosion;

    void Start()
    {
        scores = GameObject.Find("Canvas").GetComponent<Score>();
        sprite = player.GetComponent<SpriteRenderer>();
        lieskat.SetActive(true);
        box = GetComponent<BoxCollider2D>();
        box.enabled = true;
    }
    void Update()
    {
        spwn = GameObject.Find("RespawnPoint").transform.position;
        if (scores.playerlives <= 0 && !p2)
        {
            player.SetActive(false);
        }
        if (scores.playerlives2 <= 0 && p2)
        {
            player.SetActive(false);
        }
        if(scores.playerlives2 <= 0 && scores.playerlives <= 0)
        {
            Pause.GameEnd = true;
        }
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (p2)
        {
            if (collider.tag == "Bullet" || collider.tag == "Ground" || collider.tag == "Asteroid" || collider.tag == "Enemy" || collider.tag =="Worm")
            {
                StartCoroutine("invul", 2);
                scores.playerlives2--;
                scores.pCount2 = 1;
            }
            if (collider.tag == "pPickup")
            {
                if(scores.pCount2 >= 4)
                {
                    scores.score2 += 200;
                }
                else
                {
                    scores.pCount2++;
                }
            }
            if (collider.tag == "sPickup")
            {
                scores.sCount2 += 5;
            }
        }
        else
        {
            if (collider.tag == "Bullet" || collider.tag == "Ground" || collider.tag == "Asteroid" || collider.tag == "Enemy" || collider.tag =="Worm")
            {
                StartCoroutine("invul", 1);
                scores.playerlives--;
                scores.pCount = 1;
            }
            if (collider.tag == "pPickup")
            {
                if (scores.pCount >= 4)
                {
                    scores.score += 200;
                }
                else
                {
                    scores.pCount++;
                }
            }
            if (collider.tag == "sPickup")
            {
                scores.sCount += 5;
            }
        }
    }
    IEnumerator invul(int playerN)
    {
        Instantiate(explosion, transform.position, new Quaternion());
        if(playerN == 1)
        {
            PlayerMov.canMove = false;
            PlayerShoot.canShoot = false;
        }
        else if(playerN == 2)
        {
            PlayerMov.canMove2 = false;
            PlayerShoot2.canShoot2 = false;
        }
        box.enabled = false;
        sprite.enabled = false;
        lieskat.SetActive(false);
        player.transform.position = spwn;
        yield return new WaitForSeconds(0.5f);
        if (playerN == 1)
        {
            PlayerMov.canMove = true;
            PlayerShoot.canShoot = true;
        }
        else if (playerN == 2)
        {
            PlayerMov.canMove2 = true;
            PlayerShoot2.canShoot2 = true;
        }
        sprite.enabled = true;
        yield return new WaitForSeconds(0.1f);
        sprite.enabled = false;
        yield return new WaitForSeconds(0.1f);
        sprite.enabled = true;
        yield return new WaitForSeconds(0.1f);
        sprite.enabled = false;
        yield return new WaitForSeconds(0.1f);
        sprite.enabled = true;
        yield return new WaitForSeconds(0.1f);
        sprite.enabled = false;
        yield return new WaitForSeconds(0.1f);
        sprite.enabled = true;
        yield return new WaitForSeconds(0.1f);
        sprite.enabled = false;
        yield return new WaitForSeconds(0.1f);
        sprite.enabled = true;
        yield return new WaitForSeconds(0.1f);
        sprite.enabled = false;
        yield return new WaitForSeconds(0.1f);
        sprite.enabled = true;
        yield return new WaitForSeconds(0.1f);
        sprite.enabled = false;
        yield return new WaitForSeconds(0.1f);
        sprite.enabled = true;
        yield return new WaitForSeconds(0.1f);
        sprite.enabled = false;
        yield return new WaitForSeconds(0.1f);
        sprite.enabled = true;
        yield return new WaitForSeconds(0.1f);
        sprite.enabled = false;
        yield return new WaitForSeconds(0.1f);
        box.enabled = true;
        CancelInvoke("flash");
        sprite.enabled = true;
        lieskat.SetActive(true);
    }
}
