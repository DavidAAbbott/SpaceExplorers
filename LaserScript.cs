using UnityEngine;
using System.Collections;

public class LaserScript : MonoBehaviour {
    private GameObject laser;
    private GameObject laserStartCast;
    public Camera Camera;
    public float shake = 0f;
    public float shakeAmount = 0.7f;
    public float decrease = 1f;
    private GameObject camPos;
    Vector3 camOrigPos = Vector3.zero;

	void Start () {
        camPos = GameObject.Find("Cameraposition");
        laser = GameObject.Find("Laser");
        laserStartCast = GameObject.Find("LaserStartCast");
        laser.SetActive(false);
        laserStartCast.SetActive(false);

        StartCoroutine("timer");
	}
	
	void Update () {
        camOrigPos = camPos.transform.position;
        if (shake > 0f)
        {
            Vector2 rndShake = Random.insideUnitCircle * shakeAmount;
            Camera.transform.localPosition = new Vector3(rndShake.x, rndShake.y, camOrigPos.z);
            shake -= Time.deltaTime * decrease;
        }
        else
        {
            shake = 0.0f;
            Camera.transform.position = camOrigPos;
        }
	}
    IEnumerator timer()
    {
        yield return new WaitForSeconds(2f);
        while (true)
        {
            float rng = Random.Range(0.5f, 2f);
            laserStartCast.SetActive(true);
            yield return new WaitForSeconds(0.9f);
            laser.SetActive(true);
            shake = 0.5f;
            yield return new WaitForSeconds(rng);
            shake = 0.0f;
            laser.SetActive(false);
            laserStartCast.SetActive(false);
        }
    }
}
