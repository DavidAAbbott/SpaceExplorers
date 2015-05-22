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
    private bool firstP = true;
    Color color = new Color32(0, 0, 0, 0);
    private bool timer = true;

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
        if (paused && Input.GetKeyDown(KeyCode.P) && !firstP || paused && Input.GetButtonDown("Back_1") && !firstP || paused && Input.GetKeyDown(KeyCode.Escape) && !firstP || paused && Input.GetButtonDown("Start_1") && !firstP)
        {
            firstPress();
            paused = false;
            Time.timeScale = 1;
            pause.SetActive(false);
            exit.SetActive(false);
            print(firstP);
            StartCoroutine("wTime");
        }
        if (!paused && Input.GetKeyDown(KeyCode.P) && firstP && timer || !paused && Input.GetButtonDown("Back_1") && firstP && timer)
        {
            firstPress();
            paused = true;
            pause.SetActive(true);
            Time.timeScale = 0;
            print(firstP);
            timer = false;
        }
        if (!paused && Input.GetKeyDown(KeyCode.Escape) && firstP && timer || !paused && Input.GetButtonDown("Start_1") && firstP && timer)
        {
            firstPress();
            paused = true;
            Time.timeScale = 0;
            exit.SetActive(true);
            print(firstP);
            timer = false;
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
    void firstPress()
    {
        if(!firstP)
        {
            firstP = true;
        }
        else
        {
            firstP = false;
        }
    }
    IEnumerator wTime()
    {
        yield return new WaitForSeconds(0.1f);
        timer = true;
    }
}