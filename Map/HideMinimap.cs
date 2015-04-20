using UnityEngine;
using System.Collections;

public class HideMinimap : MonoBehaviour {

    private bool onoff = true;

    void Update()
    {
        if (Input.GetButtonDown("Y_1"))
        {
            onoff = !onoff;

            if (onoff)
            {
                GetComponent<Camera>().enabled = true;
            }
            else
            {
                GetComponent<Camera>().enabled = false;
            }
        }
    }
}