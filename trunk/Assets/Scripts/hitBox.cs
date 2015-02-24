using UnityEngine;
using System.Collections;

public class hitBox : MonoBehaviour {
    private BoxCollider2D box;
    private SpriteRenderer sprite;
    private GameObject player;
    private GameObject lieskat;
    private Vector2 spwn;
    private Score scores;

	void Start() {
        scores = GameObject.Find("Canvas").GetComponent<Score>();
        player = GameObject.Find("Player");
        lieskat = GameObject.Find("Lieskat");
        sprite = player.GetComponent<SpriteRenderer>();
        lieskat.SetActive(true);
        box = GetComponent<BoxCollider2D>();
        box.enabled = true;
	}
	void Update() {
        spwn = GameObject.Find("RespawnPoint").transform.position;
        if (scores.playerlives <= 0)
        {
            GameObject.Find("Player").SetActive(false);
        }
	}
    void OnTriggerEnter2D(Collider2D collider)
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
        if(collider.tag == "Asteroid")
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
