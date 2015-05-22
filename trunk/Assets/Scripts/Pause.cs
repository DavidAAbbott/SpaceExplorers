using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Pause : MonoBehaviour {
    public static bool GameEnd = false;
    public GameObject pause, gameEnd, stageEnd, exit;
    public static bool paused = false;
    public static bool stageClear = false;
    public static bool explode = false;
    public Image black;
    private bool first = true;
    Color color = new Color32(0, 0, 0, 0);

    void Start()
    {
        pause.SetActive(false);
        gameEnd.SetActive(false);
        stageEnd.SetActive(false);
        exit.SetActive(false);
        paused = false;
        explode = false;
        GameEnd = false;
        stageClear = false;
    }
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.P) || Input.GetButtonUp("Back_1"))
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
            exit.SetActive(false);
        }
        if (GameEnd)
        {
            Time.timeScale = 0;
            gameEnd.SetActive(true);
            if (Input.anyKey)
            {
                Time.timeScale = 1;
                GameEnd = false;
                Application.LoadLevel(1);
                Destroy(gameObject);
                PlayerMov.canMove = true;
                PlayerShoot.canShoot = true;
                if (MainMenu.player2)
                {
                    PlayerMov.canMove2 = true;
                    PlayerShoot2.canShoot2 = true;
                }
            }
        }
        if(explode)
        {
            StartCoroutine("explosion");
        }
        if (stageClear)
        {
            Invoke("Dim",0f);
            if(color.a >= 3)
            {
                stageEnd.SetActive(true);
                Time.timeScale = 0;
            }
            if (color.a >= 6)
            {
                CancelInvoke("Dim");
                Time.timeScale = 1;
                Application.LoadLevel(1);
                stageClear = false;
                Destroy(gameObject,0.1f);
                MoveForward.stop = false;
            }
        }
        if (Input.GetKeyUp(KeyCode.Escape) || Input.GetButtonUp("Start_1"))
        {
            paused = true;
            Time.timeScale = 0;

            exit.SetActive(true);
        }
    }
    void Dim()
    {
        color.a += 0.05f;
        black.color = color;
    }
    IEnumerator explosion()
    {
        yield return new WaitForSeconds(BossScript.explodeTime);
        stageClear = true;
    }
}