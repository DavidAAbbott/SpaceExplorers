using UnityEngine;
using System.Collections;

public class TriggerScript : MonoBehaviour {
    public GameObject[] enemies;

    void Start()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].SetActive(false);
        }
    }
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i].SetActive(true);
            }
        }
    }
}
