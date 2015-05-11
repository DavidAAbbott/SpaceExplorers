using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {
    public int playerlives = 3;
    public int playerlives2 = 3;
    public int pCount = 1;
    public int pCount2 = 1;
    public int sCount, sCount2;
    public float timer, timer2;
    public int hit, hit2, score, score2, combo, combo2;
    public bool cmb, cmb2;
    public Text guiScore, guiCombo, guiLives , guiSecondary;
    public Text guiScore2, guiCombo2, guiLives2, guiSecondary2;
    public GameObject p2UI;
    public GameObject player2;
    public float cTime = 1f;

    void Start()
    {
        guiScore.text = "Score: " + score.ToString();
        guiCombo.text = "Combo: " + combo.ToString();
        guiLives.text = "Lives: " + playerlives.ToString();
        guiSecondary.text = sCount.ToString();
        if(MainMenu.player2)
        {
            player2.SetActive(true);
            p2UI.SetActive(true);
            guiScore2.text = "Score: " + score2.ToString();
            guiCombo2.text = "Combo: " + combo2.ToString();
            guiLives2.text = "Lives: " + playerlives2.ToString();
            guiSecondary2.text = sCount2.ToString();
        }
        else
        {
            p2UI.SetActive(false);
            player2.SetActive(false);
        }
    }

    void Update()
    {
        if (timer > 0f)
        {
            timer -= Time.deltaTime;
        } 
        guiSecondary.text = sCount.ToString();
        guiLives.text = "LIVES: " + playerlives.ToString();
        guiScore.text = "SCORE: " + score.ToString();

        if (timer > 0)
        {
            cmb = true;
        }
        else
        {
            cmb = false;
            combo = 0;
        }

        guiCombo.text = "COMBO: " + combo.ToString();

        if (MainMenu.player2)
        {
            if (timer2 > 0f)
            {
                timer2 -= Time.deltaTime;
            }
            guiSecondary2.text = sCount2.ToString();
            guiLives2.text = "LIVES: " + playerlives2.ToString();
            guiScore2.text = "SCORE: " + score2.ToString();

            if (timer2 > 0)
            {
                cmb2 = true;
            }
            else
            {
                cmb2 = false;
                combo2 = 0;
            }

            guiCombo2.text = "COMBO: " + combo2.ToString();
        }
    }
}