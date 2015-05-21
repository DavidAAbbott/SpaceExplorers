using UnityEngine;
using System.Collections;

public class LaserScript : MonoBehaviour
{
    private GameObject laser, laserStartCast, laser2, laserStartCast2, camPos;
    private BoxCollider2D eye = null;
    public Camera Camera;
    public float shake = 0f;
    public float shakeAmount = 0.7f;
    public float decrease = 1f;
    Vector3 camOrigPos = Vector3.zero;
    public AudioClip bosslaser;
    public bool boss2 = false;

    void Start()
    {
        camPos = GameObject.Find("Cameraposition");
        laser = GameObject.Find("Laser");
        laser.SetActive(false);
        if (boss2)
        {
            eye = gameObject.GetComponent<BoxCollider2D>();
            eye.enabled = false;
            laser2 = null;
            laserStartCast2 = null;
            laserStartCast = null;
        }
        else
        {
            laserStartCast = GameObject.Find("LaserStartCast");
            laser2 = GameObject.Find("Laser2");
            laserStartCast2 = GameObject.Find("LaserStartCast2");
            laserStartCast.SetActive(false);
            laser2.SetActive(false);
            laserStartCast2.SetActive(false);
        }
        if (boss2)
        {
            StartCoroutine("timer2");
        }
        else
        {
            StartCoroutine("timer");
        }
    }

    void Update()
    {
        camOrigPos = camPos.transform.position;
        if (shake > 0f)
        {
            Vector2 rndShake = Random.insideUnitCircle * shakeAmount;
            Camera.transform.localPosition = new Vector3(rndShake.x, rndShake.y - 0.3f, camOrigPos.z);
            shake -= Time.deltaTime * decrease;
        }
        else
        {
            shake = 0.0f;
            Camera.transform.position = camOrigPos;
        }
    }
    IEnumerator timer()
    {
        yield return new WaitForSeconds(3f);
        while (true)
        {
            float rng = Random.Range(0.5f, 2f);
            laserStartCast.SetActive(true);
            GetComponent<AudioSource>().PlayOneShot(bosslaser);
            yield return new WaitForSeconds(0.9f);
            laser.SetActive(true);
            shake = 0.5f;
            yield return new WaitForSeconds(rng);
            shake = 0.0f;
            laser.SetActive(false);
            laserStartCast.SetActive(false);
            yield return new WaitForSeconds(0.7f);

            rng = Random.Range(0.5f, 2f);
            laserStartCast2.SetActive(true);
            GetComponent<AudioSource>().PlayOneShot(bosslaser);
            yield return new WaitForSeconds(0.9f);
            laser2.SetActive(true);
            shake = 0.5f;
            yield return new WaitForSeconds(rng);
            shake = 0.0f;
            laser2.SetActive(false);
            laserStartCast2.SetActive(false);
            yield return new WaitForSeconds(0.7f);

            rng = Random.Range(0.5f, 2f);
            laserStartCast.SetActive(true);
            laserStartCast2.SetActive(true);
            GetComponent<AudioSource>().PlayOneShot(bosslaser);
            yield return new WaitForSeconds(0.9f);
            laser.SetActive(true);
            laser2.SetActive(true);
            shake = 0.5f;
            yield return new WaitForSeconds(rng);
            shake = 0.0f;
            laser.SetActive(false);
            laser2.SetActive(false);
            laserStartCast.SetActive(false);
            laserStartCast2.SetActive(false);
            yield return new WaitForSeconds(0.7f);
        }
    }
    IEnumerator timer2()
    {
        Animator anim = laser.GetComponent<Animator>();
        Animator bAnim = gameObject.GetComponent<Animator>();
        BoxCollider2D box = laser.GetComponent<BoxCollider2D>();
        box.enabled = false;
        yield return new WaitForSeconds(0.3f);
        eye.enabled = true;
        yield return new WaitForSeconds(3f);
        while (true)
        {
            bAnim.SetInteger("animState", 1);
            yield return new WaitForSeconds(0.6f);
            float rng = Random.Range(2f, 4f);
            laser.SetActive(true);
            anim.SetBool("laserStart", true);
            GetComponent<AudioSource>().PlayOneShot(bosslaser);
            yield return new WaitForSeconds(0.9f);
            anim.SetBool("laserStart", false);
            box.enabled = true;
            eye.enabled = true;
            shake = 0.5f;
            yield return new WaitForSeconds(rng);
            bAnim.SetInteger("animState", 2);
            yield return new WaitForSeconds(0.5f);
            shake = 0.0f;
            laser.SetActive(false);
            box.enabled = false;
            yield return new WaitForSeconds(0.5f);
            eye.enabled = true;
            yield return new WaitForSeconds(3f);
        }
    }
}
