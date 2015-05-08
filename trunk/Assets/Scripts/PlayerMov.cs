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
    public static bool KBcontrols2 = false;
    public bool p2 = false;
    private float inputX, inputY, tilt;

    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            KBcontrols = !KBcontrols;
        }

        if (p2)
        {
            if (KBcontrols2)
            {
                inputX = (speed * 4 * Input.GetAxis("Horizontal2")) * Time.deltaTime;
                inputY = (speed * 4 * Input.GetAxis("Vertical2")) * Time.deltaTime;
                tilt = Input.GetAxis("Vertical2");
            }
            else
            {
                if (Input.GetAxis("DPad_XAxis_2") >= 0.1 || Input.GetAxis("DPad_XAxis_2") <= -0.1 || Input.GetAxis("DPad_YAxis_2") >= 0.1 || Input.GetAxis("DPad_YAxis_2") <= -0.1)
                {
                    inputX = (speed * Input.GetAxis("DPad_XAxis_2")) * Time.deltaTime;
                    inputY = -(speed * Input.GetAxis("DPad_YAxis_2")) * Time.deltaTime;
                    tilt = -Input.GetAxis("DPad_YAxis_2");
                }
                else
                {
                    inputX = (speed * Input.GetAxis("L_XAxis_2")) * Time.deltaTime;
                    inputY = (speed * Input.GetAxis("L_YAxis_2")) * Time.deltaTime;
                    tilt = Input.GetAxis("L_YAxis_2");
                }
            }
        }
        else
        {
            if (KBcontrols)
            {
                inputX = (speed * 4 * Input.GetAxis("Horizontal")) * Time.deltaTime;
                inputY = (speed * 4 * Input.GetAxis("Vertical")) * Time.deltaTime;
                tilt = Input.GetAxis("Vertical");
            }
            else
            {
                if (Input.GetAxis("DPad_XAxis_1") >= 0.1 || Input.GetAxis("DPad_XAxis_1") <= -0.1 || Input.GetAxis("DPad_YAxis_1") >= 0.1 || Input.GetAxis("DPad_YAxis_1") <= -0.1)
                {
                    inputX = (speed * Input.GetAxis("DPad_XAxis_1")) * Time.deltaTime;
                    inputY = -(speed * Input.GetAxis("DPad_YAxis_1")) * Time.deltaTime;
                    tilt = -Input.GetAxis("DPad_YAxis_1");
                }
                else // (Input.GetAxis("L_XAxis_1") >= 0.1 || Input.GetAxis("L_XAxis_1") <= 0.1 || Input.GetAxis("L_YAxis_1") >= 0.1 || Input.GetAxis("L_YAxis_1") <= 0.1)
                {
                    inputX = (speed * Input.GetAxis("L_XAxis_1")) * Time.deltaTime;
                    inputY = (speed * Input.GetAxis("L_YAxis_1")) * Time.deltaTime;
                    tilt = Input.GetAxis("L_YAxis_1");
                }
            }
        }

        anim.SetFloat("dir", -tilt);

        move = new Vector2(inputX, -inputY);
        move = Vector2.ClampMagnitude(move, speed * Time.deltaTime);

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
