using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenuAnim : MonoBehaviour {
    public GameObject explorers, stars;
    public Image space;
    Color color = new Color32(255,255,255,0);

	void Start () {
        StartCoroutine("timer");
        space.color = color;
        explorers.SetActive(false);
        stars.SetActive(false);
	}
	
	void Update () {
        if(space.color.a < 6f)
        {
            Invoke("Dim", 0f);
        }
        else
        {
            CancelInvoke("Dim");
        }
	}
    IEnumerator timer()
    {
        yield return new WaitForSeconds(1.8f);
        explorers.SetActive(true);
        yield return new WaitForSeconds(0.4f);
        stars.SetActive(true);
    }
    void Dim()
    {
        color.a += 0.01f;
        space.color = color;
    }
}
