using UnityEngine;
using System.Collections;

public class hitBox : MonoBehaviour {
    private int playerlives = 3;
    private int pCount = 0;
    private int sCount = 0;
    public GUIText guiL, guiP, guiS;
    private BoxCollider2D[] box;

	void Start() {
        box = GetComponents<BoxCollider2D>();
        box[0].enabled = true;
        box[1].enabled = true;
        box[2].enabled = true;
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
        box[0].enabled = false;
        box[1].enabled = false;
        box[2].enabled = false;
        yield return new WaitForSeconds(0.5f);
        box[0].enabled = true;
        box[1].enabled = true;
        box[2].enabled = true;
    }
}
