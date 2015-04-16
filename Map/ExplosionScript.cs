using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class ExplosionScript : MonoBehaviour {
    public AudioClip explosion;
    public float destroyTime = 0.7f;

    void Start()
    {
        GetComponent<AudioSource>().PlayOneShot(explosion, 1F);
        Destroy(gameObject, destroyTime);
    }
}