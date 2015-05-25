using UnityEngine;
using System.Collections;

public class DetectFollow : MonoBehaviour {
    private GameObject player;
	
	void Start () {
        player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = player.transform.position;
	}
}
