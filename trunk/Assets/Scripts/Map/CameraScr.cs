using UnityEngine;
using System.Collections;

public class CameraScr : MonoBehaviour
{
    public float dampTime = 0.15f;
    private Vector3 velocity = Vector3.zero;
    private GameObject player;
    private Transform target;

    private bool onoff;
    public float ZoomTime = 2f;
    public int NormalSize = 8;
    public int ZoomSize = 4;

    void Start()
    {
        player = GameObject.Find("Player");
    }
    void Update()
    {
        target = player.transform;

        if (Input.GetButton("RS_1"))
        {
            onoff = !onoff;

            if (onoff)
            {
                if (ZoomTime > 1)
                {
                    ZoomTime -= Time.deltaTime;
                    Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, NormalSize, Time.deltaTime * ZoomTime);
                }
            }

            else
            {
                if (ZoomTime > 1)
                {
                    ZoomTime -= Time.deltaTime;
                    Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, ZoomSize, Time.deltaTime * ZoomTime);
                }
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