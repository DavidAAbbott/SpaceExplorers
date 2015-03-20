using UnityEngine;
using System.Collections;

public class GroundCannon : MonoBehaviour {
    public GameObject enemybullet;
    public GameObject player1, player2;
    public float speed = 10f;
    private int rng = 0;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        float distance = Vector2.Distance(player1.transform.position, transform.position);
        if(distance < 10)
        {
            Vector2 dir = player1.transform.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            Quaternion qto = Quaternion.AngleAxis(angle, Vector3.forward);  
            Quaternion qto2 = Quaternion.Euler (qto.eulerAngles.x, qto.eulerAngles.y, qto.eulerAngles.z + 90);
            transform.rotation = Quaternion.Slerp(transform.rotation, qto2, 5f * Time.deltaTime);
        }
        if(distance > 10)
        {
            
        }
	}

    void Shoot()
    {
        if (MainMenu.player2)
        {
            rng = Random.Range(0, 2);
        }
        if (rng > 0)
        {
            Shot(player1);
        }
        else
        {
            Shot(player2);
        }
    }
    void Shot(GameObject player)
    {
        GameObject pNewObject;
        pNewObject = Instantiate(enemybullet) as GameObject;
        pNewObject.transform.rotation = transform.rotation;
        Vector2 pos = new Vector2(transform.position.x + 0f, transform.position.y + 0f);
        pNewObject.transform.position = pos;
        pNewObject.rigidbody2D.velocity = (player.transform.position - transform.position).normalized * speed;
    }
}
