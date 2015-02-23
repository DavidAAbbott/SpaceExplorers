using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {
    public int playerlives = 3;
    public int pCount = 1;
    public int sCount = 0;
    public float timer = 0f;
    public int combo = 0;
    public int hit, score;
    public bool cmb;
    public Text guiScore, guiCombo, guiLives , guiSecondary;

    void Start()
    {
        guiScore.text = "Score: " + score.ToString();
        guiCombo.text = "Combo: " + combo.ToString();
        guiLives.text = "Lives: " + playerlives.ToString();
        guiSecondary.text = sCount.ToString();
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
    }
}