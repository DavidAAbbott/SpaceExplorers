using UnityEngine;
using System.Collections;

public class LaserScript : MonoBehaviour {
    private GameObject laser;
    private GameObject laserStartCast;
    public Camera Camera;
    public float shake = 0f;
    public float shakeAmount = 0.7f;
    public float decrease = 1f;
    Vector3 camOrigPos = Vector3.zero;

	void Start () {
        camOrigPos = Camera.transform.position;
        laser = GameObject.Find("Laser");
        laserStartCast = GameObject.Find("LaserStartCast");
        laser.SetActive(false);
        laserStartCast.SetActive(false);

        StartCoroutine("timer");
	}
	
	void Update () {
        /*if (shake > 0)
        {
            Camera.transform.localPosition = Random.insideUnitSphere * shakeAmount;
            shake -= Time.deltaTime * decrease;
        }
        else
        {
            shake = 0.0f;
            Camera.transform.position = camOrigPos;
        }*/
	}
    IEnumerator timer()
    {
        laserStartCast.SetActive(true);
        yield return new WaitForSeconds(0.9f);
        laser.SetActive(true);
        shake = 0.5f;
        //laserStartCast.SetActive(false);
    }
}
