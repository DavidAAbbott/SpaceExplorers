using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour {

    public AudioClip PickUp;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Player")
        {
            audio.PlayOneShot(PickUp);
            gameObject.renderer.enabled = false;
            gameObject.collider2D.enabled = false;
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
