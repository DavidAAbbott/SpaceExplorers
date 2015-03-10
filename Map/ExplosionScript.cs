using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class ExplosionScript : MonoBehaviour {
    public AudioClip explosion;

    void Start()
    {
        audio.PlayOneShot(explosion, 1F);
        Destroy(gameObject, 0.7f);
    }
}