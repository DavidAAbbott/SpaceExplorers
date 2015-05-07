using UnityEngine;
using System.Collections;

public class WormScript : MonoBehaviour {
    public GameObject wormEntrance, wormExit, Worm, wormOverlayEntrance, wormOverlayExit, camPos;
    public float speed = 2f;
    private float animTime = 0.8f;
    public float gap = 2f;
    private bool canMove = false;
    private Animator anim, anim2;
    public Camera Camera;
    public float shake = 0f;
    public float shakeAmount = 0.7f;
    public float decrease = 1f;
    Vector3 camOrigPos = Vector3.zero;
    public float shakeMore = 4f;

	void Start () {
        camPos = GameObject.Find("Cameraposition");
        anim = wormEntrance.GetComponent<Animator>();
        anim2 = wormExit.GetComponent<Animator>();
        wormExit.SetActive(false);
        StartCoroutine("timer");
	}
	
	void Update () {
        camOrigPos = camPos.transform.position;
        if (shake > 0f)
        {
            Vector2 rndShake = Random.insideUnitCircle * shakeAmount;
            Camera.transform.localPosition = new Vector3(rndShake.x, rndShake.y - 0.3f, camOrigPos.z);
            shake -= Time.deltaTime * decrease;
        }
        else
        {
            shake = 0.0f;
            Camera.transform.position = camOrigPos;
        }
        if (canMove)
        {
            Worm.transform.Translate(Vector3.up * (speed) * Time.deltaTime);
        }
	}
    IEnumerator timer()
    {
        shake = 1f;
        yield return new WaitForSeconds(animTime);
        anim.SetInteger("state", 1);
        wormOverlayEntrance.SetActive(true);
        canMove = true;
        yield return new WaitForSeconds(gap / 6);
        shakeAmount *= shakeMore;
        yield return new WaitForSeconds(gap / 6);
        yield return new WaitForSeconds(gap / 4);
        wormExit.SetActive(true);
        yield return new WaitForSeconds(gap / 4);
        wormOverlayExit.SetActive(true);
        yield return new WaitForSeconds(gap / 4);
        anim.SetInteger("state", 2);
        yield return new WaitForSeconds(animTime / 2);
        wormOverlayEntrance.SetActive(false);
        yield return new WaitForSeconds(animTime / 2);
        anim2.SetInteger("state", 2);
        yield return new WaitForSeconds(animTime);
        wormOverlayExit.SetActive(false);
        Destroy(gameObject);
    }
}
