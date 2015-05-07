using UnityEngine;
using System.Collections;

public class CompassScript : MonoBehaviour
{
    public float rotationSpeed;
    private GameObject player;

    public Transform target;
    Quaternion rot;
    void Start()
    {
        player = GameObject.Find("Player");
    }
    void Update()
    {
        transform.position = player.transform.position;
        Vector2 dir = target.transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion qto = Quaternion.AngleAxis(angle, Vector3.forward);
        Quaternion qto2 = Quaternion.Euler(qto.eulerAngles.x, qto.eulerAngles.y, qto.eulerAngles.z + 90);
        transform.rotation = Quaternion.Lerp(transform.rotation, qto2, 5f * Time.deltaTime);
    }
}