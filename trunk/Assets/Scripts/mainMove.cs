using UnityEngine;
using System.Collections;

public class mainMove : MonoBehaviour {
	public Vector2 speed = new Vector2(1,20);
	private Vector2 move = new Vector2();
	private Vector2 jump = new Vector2();
	private bool facingRight = true;
    public GameObject bullet;
    public float bulletspeed = 1f;
    public float waitTime = 0.2f;
    private bool movement = true;
    public float jumpH, wallH, walljumpH;
    public float totalTime = 5f;
    private bool canfly = true;

	void Start () {
	}

	void Update () {
		SliderJoint2D slider = GetComponent<SliderJoint2D>();
		float inputX = 0f;
		float inputY = 0f;
        float wall = 0f;
		slider.enabled = false;

		if(Input.GetKeyDown(KeyCode.UpArrow))
		{
            if (IsGrounded())
            {
                canfly = true;
                inputY += jumpH;
            }
            else
            {
                if (IsWalled() && Input.GetKey(KeyCode.LeftArrow))
                {
                    rigidbody2D.velocity = new Vector2(0, 0);
                    inputY += walljumpH;
                    wall += wallH;
                    movement = false;
                    canfly = true;
                    //rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x - (100 * Time.deltaTime), rigidbody2D.velocity.y);
                    StartCoroutine(timer(waitTime));
                }
                else if (IsWalled() && Input.GetKey(KeyCode.RightArrow))
                {
                    rigidbody2D.velocity = new Vector2(0, 0);
                    inputY += walljumpH;
                    wall -= wallH;
                    movement = false;
                    canfly = true;
                    //rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x + (100 * Time.deltaTime), rigidbody2D.velocity.y);
                    StartCoroutine(timer(waitTime));
                }
            }
		}
		if(Input.GetKey(KeyCode.X))
		{
            if (!IsGrounded() && canfly == true)
			{
				slider.enabled = true;
				slider.connectedAnchor = new Vector2(transform.position.x, transform.position.y);
                StartCoroutine(timer2(waitTime));
			}
		}
        if (movement == true)
        {
            if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow))
            {
                inputX -= 0.1f;
                if (facingRight)
                {
                    Flip();
                }
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                inputX -= 0.1f;
                if (facingRight)
                {
                    Flip();
                }
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                inputX += 0.1f;
                if (!facingRight)
                {
                    Flip();
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Z) || Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

		move = new Vector2 (speed.x * inputX, 0);
		jump = new Vector2 (speed.y * wall, speed.y * inputY);
	}

	bool IsGrounded()
	{
		Vector2 pos = transform.position;
		Vector2 left = new Vector2 (pos.x - 0.17f, pos.y);
		Vector2 right = new Vector2 (pos.x + 0.2f, pos.y);
		bool re = false;
		Debug.DrawRay(left, -Vector2.up, Color.magenta, 2f);
		Debug.DrawRay(right, -Vector2.up, Color.magenta, 2f);
		RaycastHit2D hit = Physics2D.Raycast(left, -Vector2.up, 0.3f);
		RaycastHit2D hit2 = Physics2D.Raycast(right, -Vector2.up, 0.3f);
        if (hit.collider)
        {
            if (hit.collider.tag == "Floor")
            {
                re = true;
            }
        }
        else if (hit2.collider)
        {
            if (hit2.collider.tag == "Floor")
            {
                re = true;
            }
        }
		return re;
	}
    bool IsWalled()
    {
        Vector2 pos = transform.position;
        Vector2 left = new Vector2(pos.x, pos.y - 0.2f);
        Vector2 right = new Vector2(pos.x, pos.y + 0.15f);
        bool re = false;
        Debug.DrawRay(left, -Vector2.right, Color.red, 2f);
        Debug.DrawRay(right, -Vector2.right, Color.red, 2f);
        Debug.DrawRay(left, Vector2.right, Color.green, 2f);
        Debug.DrawRay(right, Vector2.right, Color.green, 2f);
        RaycastHit2D hit = Physics2D.Raycast(left, -Vector2.right, 0.3f);
        RaycastHit2D hit2 = Physics2D.Raycast(right, -Vector2.right, 0.3f);
        RaycastHit2D hit3 = Physics2D.Raycast(left, Vector2.right, 0.4f);
        RaycastHit2D hit4 = Physics2D.Raycast(right, Vector2.right, 0.4f);
        if (hit.collider)
        {
            if (hit.collider.tag == "Floor")
            {
                re = true;
            }
        }
        else if(hit2.collider)
        {
            if (hit2.collider.tag == "Floor")
            {
                re = true;
            }
        }
        else if (hit3.collider)
        {
            if (hit3.collider.tag == "Floor")
            {
                re = true;
            }
        }
        else if (hit4.collider)
        {
            if (hit4.collider.tag == "Floor")
            {
                re = true;
            }
        }
        return re;
    }

	void FixedUpdate(){
		rigidbody2D.transform.Translate(move);
		rigidbody2D.AddForce(jump);
	}

	void Flip()
	{
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
		facingRight = !facingRight;
	}

    void Shoot()
    {
        Vector2 direction = new Vector2(10, 0);
        Vector2 pos = transform.position;
        if (facingRight)
        {
            pos.x += 0.3f;
            GameObject projectile = (GameObject)Instantiate(bullet, pos, Quaternion.identity);
            projectile.rigidbody2D.velocity = direction * bulletspeed;
        }
        if (!facingRight)
        {
            pos.x -= 0.3f;
            GameObject projectile = (GameObject)Instantiate(bullet, pos, Quaternion.identity);
            projectile.rigidbody2D.velocity = -direction * bulletspeed;
        }
    }
    IEnumerator timer(float wait)
    {
        while (true)
        {
            yield return new WaitForSeconds(wait);
            movement = true;
            rigidbody2D.velocity = new Vector2(0, rigidbody2D.velocity.y);
        }
    }
    IEnumerator timer2(float wait2)
    {
        yield return new WaitForSeconds(wait2);
        canfly = false;
    }
}
