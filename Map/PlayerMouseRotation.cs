using UnityEngine;
using System.Collections;

public class PlayerMouseRotation : MonoBehaviour
{
    public float smooth = 2.0f; 

    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Quaternion shiprotate = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, shiprotate, Time.deltaTime * smooth);
    }
}