using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {
    public GUIText guiScore;
    public int score;
    public static float timer = 1f;
    private int combo = 0;
    public static int hit;
    public GUIText guiCombo;

	void Start () {
        guiScore.text = "- Score: " + score.ToString() + " -";
        guiCombo.text = "- Combo: " + combo.ToString() + " -";
	}
	
	void Update () {
        timer -= Time.deltaTime;
        guiScore.text = "- SCORE: " + score.ToString() + " -";
        guiCombo.text = "- COMBO: " + combo.ToString() + " -";

        if (timer > 0)
        {
            combo++;
            score += hit * combo;
        }
        else
        {
            combo = 0;
            score += hit;
        }
	}
}
