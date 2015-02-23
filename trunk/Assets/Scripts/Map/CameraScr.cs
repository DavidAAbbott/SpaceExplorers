using UnityEngine;
using System.Collections;

public class CameraScr : MonoBehaviour
{
    public float dampTime = 0.15f;
    private Vector3 velocity = Vector3.zero;
    private GameObject player;
    private Transform target;

    private bool onoff;
    public int ZoomSize = 4;
    public int NormalSize = 8;
    public float ZoomTime = 1f;

    void Start()
    {
        player = GameObject.Find("Player");
    }
    void Update()
    {
        target = player.transform;

        //TODO: FIX CAMERA ZOOM
        if (Input.GetButtonDown("RS_1"))
        {
            onoff = !onoff;

            if (onoff)
            {
                Camera.main.orthographicSize = Mathf.Lerp(camera.orthographicSize, ZoomSize, Time.deltaTime * ZoomTime);
            }
            else
            {
                Camera.main.orthographicSize = Mathf.Lerp(camera.orthographicSize, NormalSize, Time.deltaTime * ZoomTime);
            }
        }
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