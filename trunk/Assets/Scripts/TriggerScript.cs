using UnityEngine;
using System.Collections;

public class TriggerScript : MonoBehaviour {
    public GameObject[] enemies;
    public bool slowTrigger = false;
    public bool backTrigger = false;
    public bool stopTrigger = false;

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
        if (collider.tag == "Respawn")
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i].SetActive(true);
            }
            if(slowTrigger && !backTrigger && !stopTrigger)
            {
                MoveForward.slow = true;
                BackgroundScroll.moving = false;
            }
            if(!slowTrigger && backTrigger && !stopTrigger)
            {
                BackgroundScroll.moving = false;
                MoveForward.back = true;
            }
            if (!slowTrigger && !backTrigger && stopTrigger)
            {
                MoveForward.stop = true;
                BackgroundScroll.moving = false;
                MoveForward.back = false;
            }
        }
    }
}
