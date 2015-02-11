using UnityEngine;
using System.Collections;

public class lieskaScript : MonoBehaviour
{

    private Animator anim;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
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
}
