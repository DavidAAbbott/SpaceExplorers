using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public float volume = 1;
    public static bool player2 = false;
    private bool KBcontrols1;
    private bool KBcontrols2;

    void Start()
    {
        KBcontrols1 = PlayerMovement.KBcontrols;
        KBcontrols2 = Player2Turret.KBcontrols;
    }


    //Start Game
    public void ChangeToScene(int sceneToChangeTo)
    {
        Application.LoadLevel(sceneToChangeTo);
    }

    //Mute audio
    public void MuteAudio(bool isOn)
    {
        if (isOn == false)
        {
            AudioListener.pause = true;
            AudioListener.volume = 0;
        }
    }

    //Adjust volume
    public void ChangeVolume(float newVolume)
    {
        volume = newVolume;
        AudioListener.volume = volume;
    }

    //Number of players
    public void NumberOfPlayers(bool p2)
    {
        player2 = p2;
    }

    //Choose controls
    public void Keyboard(bool isOn)
    {
        if (isOn == true)
        {
            KBcontrols1 = true;
            KBcontrols2 = true;
        }
    }

    public void Controller(bool isOn)
    {
        if (isOn == true)
        {
            KBcontrols1 = false;
            KBcontrols2 = false;
        }
    }
}