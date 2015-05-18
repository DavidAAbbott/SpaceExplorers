using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class ExplosionScript : MonoBehaviour {
    public AudioClip explosion;
    public float destroyTime = 0.7f;
    public float hitBoxTimer = 0.6f;
    public bool bomb = false;
    private CircleCollider2D coll = null;

    void Start()
    {
        if (bomb)
        {
            coll = gameObject.GetComponent<CircleCollider2D>();
            StartCoroutine("timer");
        }
        GetComponent<AudioSource>().PlayOneShot(explosion);
        Destroy(gameObject, destroyTime);
    }
    IEnumerator timer()
    {
        if (bomb)
        {
            yield return new WaitForSeconds(hitBoxTimer);
            coll.enabled = false;
        }
    }
}