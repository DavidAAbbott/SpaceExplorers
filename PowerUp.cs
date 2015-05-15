using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour {

    public AudioClip PickUp;
    public GameObject pickupFlash;
    public float waveHeight = 5f;
    public float waveSpeed = 2f;

    void Update()
    {
        float yPos = 0f;
        yPos = Mathf.Sin(Time.time * waveSpeed) * waveHeight / 6;
        transform.Translate(new Vector3(0, yPos, 0) * Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Player")
        {
            GetComponent<AudioSource>().PlayOneShot(PickUp);
            gameObject.GetComponent<Renderer>().enabled = false;
            gameObject.GetComponent<Collider2D>().enabled = false;
            GameObject pNewObject;
            pNewObject = Instantiate(pickupFlash, transform.position, new Quaternion()) as GameObject;
            Destroy(pNewObject, 1f);
            Destroy(gameObject, 1f);
        }
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "Boundary")
        {
            Destroy(gameObject, 0.001f);
        }
    }
}
