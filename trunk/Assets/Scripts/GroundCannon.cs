using UnityEngine;
using System.Collections;

public class GroundCannon : MonoBehaviour {
    public GameObject cannonBullet, BulletSpawnPoint;
    private GameObject player1, player2;
    public float speed = 10f;
    private int rng = 0;
    private bool inrange = false;
    public float range = 10f;
    public float bulletRotation = 0f;
    public float shootInterval = 2f;
    public int numberOfShots = 1;
    public float waitTime = 0f;
    public bool groundCannon = false;

	// Use this for initialization
	void Start () {
        player1 = GameObject.Find("Player");
        player2 = GameObject.Find("Player2");
        if (groundCannon)
        {
            InvokeRepeating("ShootCannon", 0, shootInterval);
        }
        else
        {
            StartCoroutine(Shoot());
        }
	}
	
	// Update is called once per frame
	void Update () {
        float distance;
        distance = Vector2.Distance(player1.transform.position, transform.position);
        if(distance < range)
        {
            inrange = true;
            Vector2 dir = player1.transform.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            Quaternion qto = Quaternion.AngleAxis(angle, Vector3.forward);  
            Quaternion qto2 = Quaternion.Euler (qto.eulerAngles.x, qto.eulerAngles.y, qto.eulerAngles.z + 90);
            transform.rotation = Quaternion.Slerp(transform.rotation, qto2, 5f * Time.deltaTime);
        }
        if(distance > range)
        {
            inrange = false;
        }
	}

    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(waitTime);
        if (inrange)
        {
            if (MainMenu.player2)
            {
                rng = Random.Range(0, 2);
            }
            if (rng > 0 && player2 != null)
            {
                for (int i = 0; i < numberOfShots; i++)
                {
                    Shot(player2);
                    yield return new WaitForSeconds(shootInterval);
                }
            }
            /*if (player1 = null)
            {
                for (int i = 0; i < numberOfShots; i++)
                {
                    Shot(player2);
                    yield return new WaitForSeconds(shootInterval);
                }
            }*/
            else
            {
                for (int i = 0; i < numberOfShots; i++)
                {
                    Shot(player1);
                    yield return new WaitForSeconds(shootInterval);
                }
            }
        }
    }
    void ShootCannon()
    {
        if (inrange)
        {
            if (MainMenu.player2)
            {
                rng = Random.Range(0, 2);
            }
            if (rng > 0 && player2 != null)
            {
                Shot(player2);
            }
            else
            {
                Shot(player1);
            }
        }
    }
    void Shot(GameObject player)
    {
        GameObject pNewObject;
        pNewObject = Instantiate(cannonBullet) as GameObject;
        var trot = transform.rotation;
        trot.x -= bulletRotation;
        pNewObject.transform.rotation = trot;
        Vector2 pos = new Vector2(BulletSpawnPoint.transform.position.x, BulletSpawnPoint.transform.position.y);
        pNewObject.transform.position = pos;
        pNewObject.GetComponent<Rigidbody2D>().velocity = (player.transform.position - transform.position).normalized * (speed*50);
    }
}
