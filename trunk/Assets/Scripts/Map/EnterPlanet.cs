using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnterPlanet : MonoBehaviour
{
    public Text openMenu;
    public Text planet;
    public Text planetDesc;
    public Text enter;
    public Text exit;
    public Image menuBG;
    private bool intrigger = false;
    private bool menushowing = false;

    void Start()
    {
        openMenu.enabled = false;
        planet.enabled = false;
        planetDesc.enabled = false;
        menuBG.enabled = false;
        enter.enabled = false;
        exit.enabled = false;
    }

    void Update()
    {
        if (Input.GetButtonUp("A_1") && intrigger == true)
        {
            openMenu.enabled = false;
            menushowing = true;
            planet.enabled = true;
            planetDesc.enabled = true;
            menuBG.enabled = true;
            enter.enabled = true;
            exit.enabled = true;
            Time.timeScale = 0f; 
        }

        if (Input.GetButton("A_1") && menushowing == true)
        {
            Application.LoadLevel(2);
            Time.timeScale = 1f;
        }

        if (Input.GetButton("B_1") && menushowing == true)
        {
            menushowing = false;
            planet.enabled = false;
            planetDesc.enabled = false;
            menuBG.enabled = false;
            enter.enabled = false;
            exit.enabled = false;
            Time.timeScale = 1f;
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            intrigger = true;
            openMenu.enabled = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        intrigger = false;
        openMenu.enabled = false;
    }
}