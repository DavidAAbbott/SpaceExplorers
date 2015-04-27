using UnityEngine;
using System.Collections;

public class OrbitalRotation : MonoBehaviour
{
    public float OrbitSpeed;
    public float OrbitCenterSpeed;
    public bool inOrbit = true;

    void Update()
    {
        if (inOrbit == true)
        {
            transform.Rotate(Vector3.up * OrbitSpeed * Time.deltaTime);
        }
        else
        {
            transform.Rotate(0, 0, OrbitCenterSpeed * Time.deltaTime);
        }
    }
}