using UnityEngine;
using System.Collections;

public class CameraScr : MonoBehaviour
{
    public float dampTime = 0.15f;
    private Vector3 velocity = Vector3.zero;
    private GameObject player;
    private Transform target;

    void Start()
    {
        player = GameObject.Find("Player");
    }
    void Update()
    {
        target = player.transform;
    }
    void FixedUpdate()
    {
        if (target)
        {
            Vector3 point = camera.WorldToViewportPoint(target.position);
            Vector3 delta = target.position - camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z));
            Vector3 destination = transform.position + delta;
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
        }
    }
}
