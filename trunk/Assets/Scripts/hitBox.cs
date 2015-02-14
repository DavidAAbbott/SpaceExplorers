using UnityEngine;
using System.Collections;

public class hitBox : MonoBehaviour {
    private int playerlives = 3;
    public static int pCount = 1;
    public static int sCount = 0;
    public GUIText guiL, guiP, guiS;
    private BoxCollider2D box;
    private SpriteRenderer sprite;
    private GameObject player;
    private GameObject lieskat;
    private Vector2 spwn;

	void Start() {
        player = GameObject.Find("Player");
        lieskat = GameObject.Find("Lieskat");
        sprite = player.GetComponent<SpriteRenderer>();
        lieskat.SetActive(true);
        box = GetComponent<BoxCollider2D>();
        box.enabled = true;
        spwn = player.transform.position;
        guiL.text = "- Lives: " + playerlives.ToString() + " -";
        guiP.text = pCount.ToString();
        guiS.text = sCount.ToString();
	}
	void Update() {
        guiP.text = pCount.ToString();
        guiS.text = sCount.ToString();
        guiL.text = "- LIVES: " + playerlives.ToString() + " -";
        if (playerlives <= 0)
        {
            GameObject.Find("Player").SetActive(false);
        }
	}
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Bullet")
        {
            StartCoroutine("invul");
            playerlives--;
        }
        if (collider.tag == "pPickup")
        {
            pCount++;
        }
        if (collider.tag == "sPickup")
        {
            sCount++;
        }
        if(collider.tag == "Asteroid")
        {
            StartCoroutine("invul");
            playerlives--;
        }
    }
    IEnumerator invul()
    {
        box.enabled = false;
        sprite.enabled = false;
        lieskat.SetActive(false);
        player.transform.position = spwn;
        yield return new WaitForSeconds(0.1f);
        sprite.enabled = true;
        lieskat.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        sprite.enabled = false;
        lieskat.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        sprite.enabled = true;
        lieskat.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        sprite.enabled = false;
        lieskat.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        sprite.enabled = true;
        lieskat.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        sprite.enabled = false;
        lieskat.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        sprite.enabled = true;
        lieskat.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        sprite.enabled = false;
        lieskat.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        box.enabled = true;
        sprite.enabled = true;
        lieskat.SetActive(true);
    }
}
