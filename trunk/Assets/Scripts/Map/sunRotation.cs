using UnityEngine;
using System.Collections;

public class sunRotation : MonoBehaviour {

    public float rotationSpeed = 5.0f;

    void Update() 
    {
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime); 
    }
}
