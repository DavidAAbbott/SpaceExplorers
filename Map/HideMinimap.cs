using UnityEngine;
using System.Collections;

public class HideMinimap : MonoBehaviour {

    private bool onoff = true;

    void Update()
    {
        if (Input.GetButtonDown("A_1"))
        {
            onoff = !onoff;

            if (onoff)
            {
                camera.enabled = true;
            }
            else
            {
                camera.enabled = false;
            }
        }
    }
}