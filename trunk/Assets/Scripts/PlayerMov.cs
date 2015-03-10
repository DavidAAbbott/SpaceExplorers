using UnityEngine;
using System.Collections;


public class PlayerMov : MonoBehaviour
{
    public float speed = 2f;
    private Vector2 move;
    private Animator anim;
    public static bool canMove = true;
    public static bool canMove2 = true;
    public static bool KBcontrols = false;
    public bool KBcontrols1 = false;
    public bool p2 = false;

    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        float inputX, inputY, tilt;
        KBcontrols = KBcontrols1;

        if (p2)
        {
            if (KBcontrols)
            {
                inputX = (speed * Input.GetAxis("Horizontal2")) * Time.deltaTime;
                inputY = (speed * Input.GetAxis("Vertical2")) * Time.deltaTime;
                tilt = Input.GetAxis("Vertical2");
            }
            else
            {
                inputX = (speed * Input.GetAxis("L_XAxis_2")) * Time.deltaTime;
                inputY = (speed * Input.GetAxis("L_YAxis_2")) * Time.deltaTime;
                tilt = Input.GetAxis("L_YAxis_2");
            }
        }
        else
        {
            if (KBcontrols)
            {
                inputX = (speed * Input.GetAxis("Horizontal")) * Time.deltaTime;
                inputY = (speed * Input.GetAxis("Vertical")) * Time.deltaTime;
                tilt = Input.GetAxis("Vertical");
            }
            else
            {
                inputX = (speed * Input.GetAxis("L_XAxis_1")) * Time.deltaTime;
                inputY = (speed * Input.GetAxis("L_YAxis_1")) * Time.deltaTime;
                tilt = Input.GetAxis("L_YAxis_1");
            }
        }

        anim.SetFloat("dir", -tilt);

        move = new Vector2(inputX, -inputY);
        move = Vector2.ClampMagnitude(move, speed * Time.deltaTime);
    }
    void FixedUpdate()
    {
        if (canMove && !p2)
        {
            transform.Translate(move);
        }
        else if (canMove2 && p2)
        {
            transform.Translate(move);
        }
    }
}
