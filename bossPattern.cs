/*using UnityEngine;
using System.Collections;

public class bossPattern : MonoBehaviour {
    public float bulletspeed0 = 1f;
    public float bulletspeed1 = 2f;
    public float bulletspeed2 = 2f;
    public float bulletspeed3 = 1f;
    public GameObject bullet0;
    public GameObject bullet1;
    public GameObject bullet2;
    public GameObject bullet3;
    private GameObject player;
    private int hp = 100;
    public GUIText guit;
    public float fireRate0 = 0.1f;
    public float fireRate1 = 1f;
    public float fireRate2 = 1f;
    public float fireRate3 = 0.1f;
	public GUIText guiQ;
	private bool ragemode = false;
	private SpriteRenderer sprite;
	private Color origcolor;
    public ParticleSystem particles;

	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        InvokeRepeating("rndPattern", 1f, 1f);
		guiQ.enabled = false;
		sprite = GetComponent<SpriteRenderer>();
		origcolor = sprite.color;
		sprite.color = new Color(255f, 255f, 255f, 255f);
        particles.enableEmission = false;
	}
	void Update () {
        guit.text = "- Boss HP: " + hp.ToString() + " -";
        if (hp <= 0)
        {
			player.GetComponent<BoxCollider2D>().enabled = false;
            CancelInvoke("rndPattern");
            StartCoroutine("death");
        }
		if(hp <= 50)
		{
			ragemode = true;
		}
	}
    void FixedUpdate()
    {
    }
    void Pattern0()
    {
        Vector2 direction = new Vector2(Random.Range(-20, 20),Random.Range(-20, 20));
        GameObject projectile = (GameObject)Instantiate(bullet0, transform.position, Quaternion.identity);
        projectile.rigidbody2D.velocity = direction * bulletspeed0;
    }
    void Pattern1()
    {
        GameObject projectile = (GameObject)Instantiate(bullet1, transform.position, Quaternion.identity);
        projectile.rigidbody2D.velocity = (new Vector2(player.transform.position.x, player.transform.position.y)) * bulletspeed1;
    }
    void Pattern2()
    {
        GameObject projectile = (GameObject)Instantiate(bullet2, transform.position, Quaternion.identity);
        projectile.rigidbody2D.velocity = (new Vector2(player.transform.position.x, player.transform.position.y)) * bulletspeed2;

        GameObject projectile2 = (GameObject)Instantiate(bullet2, transform.position, Quaternion.identity);
        projectile2.rigidbody2D.velocity = (new Vector2(-player.transform.position.x, player.transform.position.y)) * bulletspeed2;

        GameObject projectile3 = (GameObject)Instantiate(bullet2, transform.position, Quaternion.identity);
        projectile3.rigidbody2D.velocity = (new Vector2(player.transform.position.x, -player.transform.position.y)) * bulletspeed2;

        GameObject projectile4 = (GameObject)Instantiate(bullet2, transform.position, Quaternion.identity);
        projectile4.rigidbody2D.velocity = (new Vector2(-player.transform.position.x, -player.transform.position.y)) * bulletspeed2;
    }
    void Pattern3()
    {
        Vector2 direction = new Vector2(Random.Range(-20, 20), Random.Range(-20, 20));
        GameObject projectile = (GameObject)Instantiate(bullet3, transform.position, Quaternion.identity);
        projectile.rigidbody2D.velocity = direction * bulletspeed3;

        Vector2 direction2 = new Vector2(Random.Range(-20, 20), Random.Range(-20, 20));
        GameObject projectile2 = (GameObject)Instantiate(bullet3, transform.position, Quaternion.identity);
        projectile2.rigidbody2D.velocity = direction2 * bulletspeed3;

        Vector2 direction3 = new Vector2(Random.Range(-20, 20), Random.Range(-20, 20));
        GameObject projectile3 = (GameObject)Instantiate(bullet3, transform.position, Quaternion.identity);
        projectile3.rigidbody2D.velocity = direction3 * bulletspeed3;

        Vector2 direction4 = new Vector2(Random.Range(-20, 20), Random.Range(-20, 20));
        GameObject projectile4 = (GameObject)Instantiate(bullet3, transform.position, Quaternion.identity);
        projectile4.rigidbody2D.velocity = direction4 * bulletspeed3;
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "pBullet")
        {
            hp--;
			StartCoroutine("flash");
        }
    }
    void rndPattern()
    {
        CancelInvoke("Pattern0");
        CancelInvoke("Pattern1");
        CancelInvoke("Pattern2");
        CancelInvoke("Pattern3");
        int rnd = Random.Range(0, 5);
		if(ragemode == true)
		{
        	if (rnd == 0)
        	{
            	InvokeRepeating("Pattern0", 0.1f, fireRate0 / 2);
        	}
        	else if (rnd == 1)
        	{
            	InvokeRepeating("Pattern1", 0.1f, fireRate1 / 2);
        	}
        	else if (rnd == 2)
        	{
				InvokeRepeating("Pattern2", 0.1f, fireRate0 / 2);
        	}
        	else if (rnd == 3)
        	{
           		 InvokeRepeating("Pattern3", 0.1f, fireRate3 / 2);
        	}
			else
			{
				InvokeRepeating("Pattern0", 0.1f, fireRate0 / 2);
				InvokeRepeating("Pattern2", 0.1f, fireRate0 / 2);
				InvokeRepeating("Pattern3", 0.1f, fireRate3 / 2);
			}
		}
		else
		{
			if (rnd == 0)
			{
				InvokeRepeating("Pattern0", 0.1f, fireRate0);
			}
			else if (rnd == 1)
			{
				InvokeRepeating("Pattern1", 0.1f, fireRate1);
			}
			else if (rnd == 2)
			{
				InvokeRepeating("Pattern2", 0.1f, fireRate2);
			}
			else if (rnd == 3)
			{
				InvokeRepeating("Pattern3", 0.1f, fireRate3);
			}
		}
    }
	IEnumerator flash()
	{
		sprite.color = origcolor;
		yield return new WaitForSeconds(0.1f);
		sprite.color = new Color(255f, 255f, 255f,255f);
	}
    IEnumerator death()
    {
        particles.enableEmission = true;
        GameObject.Find("Boss").GetComponent<BoxCollider2D>().enabled = false;
        yield return new WaitForSeconds(1f);
        GameObject.Find("Boss").SetActive(false);
        Pause.GameEnd = true;
        guiQ.enabled = true;
    }
}*/