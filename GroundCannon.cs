using UnityEngine;
using System.Collections;

public class GroundCannon : MonoBehaviour {
    public GameObject enemybullet;
    public GameObject player, player2;
    public float speed = 10f;
    private int rng = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        var newRotation = Quaternion.LookRotation(transform.position - player.transform.position);
        newRotation.x = 0;
        //newRotation.z = 0;
        newRotation.y = 0;
        float rotationDamp = Time.deltaTime * 15;
        transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, rotationDamp);
	}

    void Shoot()
    {
        if (MainMenu.player2)
        {
            rng = Random.Range(0, 2);
        }
        if (rng > 0)
        {
            
        }
        else
        {
            
        }
    }
}
