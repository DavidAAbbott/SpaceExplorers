using UnityEngine;
using System.Collections;

public class lieskaScript : MonoBehaviour
{
    private Animator anim;
    public bool middle = false;
    public bool p2 = false;

    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (p2)
        {
            if (PlayerMov.KBcontrols2)
            {
                if (!middle)
                {
                    if (Input.GetAxis("Horizontal2") < 0)
                    {
                        anim.SetBool("x-", true);
                    }
                    else
                    {
                        anim.SetBool("x-", false);
                    }
                }
                else
                {
                    if (Input.GetAxis("Horizontal2") > 0)
                    {
                        anim.SetBool("x+", true);
                    }
                    else if (Input.GetAxis("Horizontal2") < 0)
                    {
                        anim.SetBool("x-", true);
                    }
                    else
                    {
                        anim.SetBool("x+", false);
                        anim.SetBool("x-", false);
                    }
                }
            }
            else
            {
                if (!middle)
                {
                    if (Input.GetAxis("L_XAxis_2") < 0)
                    {
                        anim.SetBool("x-", true);
                    }
                    else
                    {
                        anim.SetBool("x-", false);
                    }
                }
                else
                {
                    if (Input.GetAxis("L_XAxis_2") > 0)
                    {
                        anim.SetBool("x+", true);
                    }
                    else if (Input.GetAxis("L_XAxis_2") < 0)
                    {
                        anim.SetBool("x-", true);
                    }
                    else
                    {
                        anim.SetBool("x+", false);
                        anim.SetBool("x-", false);
                    }
                }
            }
        }
        else
        {
            if (PlayerMov.KBcontrols)
            {
                if (!middle)
                {
                    if (Input.GetAxis("Horizontal") < 0)
                    {
                        anim.SetBool("x-", true);
                    }
                    else
                    {
                        anim.SetBool("x-", false);
                    }
                }
                else
                {
                    if (Input.GetAxis("Horizontal") > 0)
                    {
                        anim.SetBool("x+", true);
                    }
                    else if (Input.GetAxis("Horizontal") < 0)
                    {
                        anim.SetBool("x-", true);
                    }
                    else
                    {
                        anim.SetBool("x+", false);
                        anim.SetBool("x-", false);
                    }
                }
            }
            else
            {
                if (!middle)
                {
                    if (Input.GetAxis("L_XAxis_1") < 0)
                    {
                        anim.SetBool("x-", true);
                    }
                    else
                    {
                        anim.SetBool("x-", false);
                    }
                }
                else
                {
                    if (Input.GetAxis("L_XAxis_1") > 0)
                    {
                        anim.SetBool("x+", true);
                    }
                    else if (Input.GetAxis("L_XAxis_1") < 0)
                    {
                        anim.SetBool("x-", true);
                    }
                    else
                    {
                        anim.SetBool("x+", false);
                        anim.SetBool("x-", false);
                    }
                }
            }
        }
    }
}
