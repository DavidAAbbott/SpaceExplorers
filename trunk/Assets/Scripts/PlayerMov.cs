using UnityEngine;
using System.Collections;

public class PlayerMov : MonoBehaviour {
    public float speed = 2f;
    public int lives = 3;
    private Vector2 move;
    private Animator anim;
    public GameObject explosion;

	void Start () {
        anim = GetComponent<Animator>();
	}
	void Update () {
        float inputX, inputY;
        inputX = (speed * Input.GetAxis("L_XAxis_1")) * Time.deltaTime;
        inputY = (speed * Input.GetAxis("L_YAxis_1")) * Time.deltaTime;

        float tilt = Input.GetAxis("L_YAxis_1");
        anim.SetFloat("dir", -tilt);

        move = new Vector2(inputX, -inputY);
        move = Vector2.ClampMagnitude(move, speed * Time.deltaTime);

        if (lives == 0)
        {
            Destroy(gameObject);
            Instantiate(explosion, transform.position, new Quaternion());
        }
	}
    void FixedUpdate() {
        transform.Translate(move);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "EnemyBullet")
        {
            lives = lives - 1;  
        }
    }
}
