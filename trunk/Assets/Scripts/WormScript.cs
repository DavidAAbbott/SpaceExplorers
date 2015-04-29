using UnityEngine;
using System.Collections;

public class WormScript : MonoBehaviour {
    public GameObject wormEntrance, wormExit, Worm;
    public float speed = 2f;
    private float animTime = 0.8f;
    public float gap = 2f;
    private bool canMove = false;
    private Animator anim, anim2;

	void Start () {
        anim = wormEntrance.GetComponent<Animator>();
        anim2 = wormExit.GetComponent<Animator>();
        wormExit.SetActive(false);
        StartCoroutine("timer");
	}
	
	void Update () {
        if (canMove)
        {
            Worm.transform.Translate(Vector3.up * (speed) * Time.deltaTime);
        }
	}
    IEnumerator timer()
    {
        yield return new WaitForSeconds(animTime);
        anim.SetInteger("state", 1);
        canMove = true;
        yield return new WaitForSeconds(gap / 2);
        wormExit.SetActive(true);
        yield return new WaitForSeconds(gap / 2);
        anim.SetInteger("state", 2);
        yield return new WaitForSeconds(animTime);
        anim2.SetInteger("state", 2);
        yield return new WaitForSeconds(animTime);
        Destroy(gameObject);
    }
}
