using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DroppingWave : MonoBehaviour {
    private List<Transform> enemies = new List<Transform>();
    public float waitTime = 0.4f;
    private int timerInt = 0;
    private bool firstOne = true;

	void Start () {
        for (int i = 0; i < transform.childCount; i++)
        {
            enemies.Add(transform.GetChild(i));
            enemies[i].gameObject.SetActive(false);
        }
        StartCoroutine("timer");
	}
	
	void Update () {

	}
    IEnumerator timer()
    {
        while(timerInt < transform.childCount)
        {
            if (!firstOne)
            {
                yield return new WaitForSeconds(waitTime);
            }
            else
            {
                firstOne = false;
            }
            enemies[timerInt].gameObject.SetActive(true);
            timerInt++;
        }
    }
}
