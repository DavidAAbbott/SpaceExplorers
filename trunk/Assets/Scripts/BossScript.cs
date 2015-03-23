using UnityEngine;
using System.Collections;

public class BossScript : MonoBehaviour {
    private float angle = 0;
    public float seconds = 5;
    public float bulletSpeed = 0.2f;
    private float speed; //2*PI in degress is 360, so you get 5 seconds to complete a circle
    public float radius = 2;
    private Vector2 pos = Vector2.zero;
    private Vector2 origpos = Vector2.zero;
    public float BulletSpawnX = 1f;
    public float BulletSpawnY = 1f;
    public GameObject bomb;
    public GameObject explosion;

	void Start () {
        StartCoroutine("Pattern");
        origpos = transform.position;
        speed = (2 * Mathf.PI) / seconds;
	}
	
	void Update () {
	    angle += speed*Time.deltaTime;
        pos.x = Mathf.Cos(angle)*radius + origpos.x;
        pos.y = Mathf.Sin(angle)*radius + origpos.y;

        transform.position = pos;
	}
    void Shoot(float pitch, float time)
    {
        GameObject pNewObject;
        pNewObject = Instantiate(bomb) as GameObject;
        pNewObject.transform.rotation = transform.rotation;
        Vector2 pos = transform.position;
        pos.x += BulletSpawnX;
        pos.y += BulletSpawnY;
        pNewObject.transform.position = pos;
        pNewObject.GetComponent<Rigidbody2D>().velocity = new Vector2(18f, -16f) * -bulletSpeed / pitch;
        Destroy(pNewObject, time);
        StartCoroutine("timer", time);
    }
    IEnumerator Pattern()
    {
        yield return null;
        while (true)
        {
            Shoot(1.1f, 0.8f);
            yield return new WaitForSeconds(0.7f);
            Shoot(0.8f, 1f);
            yield return new WaitForSeconds(0.7f);
            Shoot(0.7f, 1.2f);
            yield return new WaitForSeconds(1.2f);
        }
    }
    IEnumerator timer(float time)
    {
        yield return new WaitForSeconds(time);
        GameObject pNewObject;
        pNewObject = Instantiate(explosion) as GameObject;
    }
}
