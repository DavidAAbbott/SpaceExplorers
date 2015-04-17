using UnityEngine;
using System.Collections;

public class EnterPlanet : MonoBehaviour {
    public GUIText menu;
    private bool intrigger = false;

    void Start()
    {
        menu.enabled = false;
    }
    void Update()
    {
        if (Input.GetButton("X_1") && intrigger == true)
        {
            Application.LoadLevel(2);
        }
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            menu.enabled = true;
            intrigger = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        intrigger = false;
        menu.enabled = false;
    }
}