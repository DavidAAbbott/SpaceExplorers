using UnityEngine;
using System.Collections;

public class LaserScript : MonoBehaviour {
    private GameObject laser;
    private GameObject laserStartCast;

	void Start () {
        laser = GameObject.Find("Laser");
        laserStartCast = GameObject.Find("LaserStartCast");
        laser.SetActive(false);
        laserStartCast.SetActive(false);

        StartCoroutine("timer");
	}
	
	void Update () {
	}
    IEnumerator timer()
    {
        laserStartCast.SetActive(true);
        yield return new WaitForSeconds(0.9f);
        laser.SetActive(true);
        //laserStartCast.SetActive(false);
    }
}
