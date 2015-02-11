using UnityEngine;
using System.Collections;

public class PlanetRotation : MonoBehaviour {

    public float rotationspeed;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.up * rotationspeed * Time.deltaTime);
	}
}
