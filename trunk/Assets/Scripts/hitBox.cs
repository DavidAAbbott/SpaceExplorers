using UnityEngine;
using System.Collections;

public class hitBox : MonoBehaviour {
    private BoxCollider2D box;
    private SpriteRenderer sprite;
    public GameObject player;
    public GameObject lieskat;
    private Vector2 spwn;
    private Score scores;
    public bool p2 = false;

	void Start() {
        scores = GameObject.Find("Canvas").GetComponent<Score>();
        sprite = player.GetComponent<SpriteRenderer>();
        lieskat.SetActive(true);
        box = GetComponent<BoxCollider2D>();
        box.enabled = true;
	}
	void Update() {
        spwn = GameObject.Find("RespawnPoint").transform.position;
        if (scores.playerlives <= 0)
        {
            player.SetActive(false);
        }
	}
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(p2)
        {
            if (collider.tag == "Bullet")
            {
                StartCoroutine("invul");
                scores.playerlives2--;
                scores.pCount2 = 1;
            }
            if (collider.tag == "pPickup")
            {
                scores.pCount2++;
            }
            if (collider.tag == "sPickup")
            {
                scores.sCount2++;
            }
            if (collider.tag == "Asteroid")
            {
                StartCoroutine("invul");
                scores.playerlives2--;
            }
            if (collider.tag == "Ground")
            {
                StartCoroutine("invul");
                scores.playerlives2--;
            }
        }
        else
        {
            if (collider.tag == "Bullet")
            {
                StartCoroutine("invul");
                scores.playerlives--;
                scores.pCount = 1;
            }
            if (collider.tag == "pPickup")
            {
                scores.pCount++;
            }
            if (collider.tag == "sPickup")
            {
                scores.sCount++;
            }
            if (collider.tag == "Asteroid")
            {
                StartCoroutine("invul");
                scores.playerlives--;
            }
            if (collider.tag == "Ground")
            {
                StartCoroutine("invul");
                scores.playerlives--;
            }
        }
    }
    IEnumerator invul()
    {
        PlayerMov.canMove = false;
        PlayerShoot.canShoot = false;
        box.enabled = false;
        sprite.enabled = false;
        lieskat.SetActive(false);
        player.transform.position = spwn;
        yield return new WaitForSeconds(0.5f);
        PlayerMov.canMove = true;
        PlayerShoot.canShoot = true;
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
