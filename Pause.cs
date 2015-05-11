using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Pause : MonoBehaviour {
    public static bool GameEnd = false;
    private GameObject pause;
    public static bool paused = false;

    void Start()
    {
        pause = GameObject.Find("Pause");
        pause.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.P) || Input.GetButton("Start_1"))
        {
            paused = true;
            pause.SetActive(true);
            Time.timeScale = 0;
        }
        if (paused && Input.anyKey)
        {
            paused = false;
            Time.timeScale = 1;
            pause.SetActive(false);
        }
        if (GameEnd)
        {
            Time.timeScale = 0;
            if (Input.GetKey(KeyCode.R))
            {
                Time.timeScale = 1;
                GameEnd = false;
                //Application.LoadLevel(0);
            }
        }
    }
}