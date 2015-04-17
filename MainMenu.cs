using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public float volume = 1;
    public static bool player2 = false;

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
        if (isOn)
        {
            PlayerMovement.KBcontrols = true;
            PlayerMov.KBcontrols = true;
            PlayerTurret.KBcontrols = true;
            PlayerTurretShot.KBcontrols = true;
        }
    }

    public void Controller(bool isOn)
    {
        if (isOn)
        {
            PlayerMovement.KBcontrols = false;
            PlayerMov.KBcontrols = false;
            PlayerTurret.KBcontrols = false;
            PlayerTurretShot.KBcontrols = false;
        }
    }
    public void Keyboard2(bool isOn)
    {
        if (isOn)
        {
            PlayerTurret.KBcontrols2 = true;
            PlayerTurretShot.KBcontrols2 = true;
        }
    }

    public void Controller2(bool isOn)
    {
        if (isOn)
        {
            PlayerTurret.KBcontrols2 = false;
            PlayerTurretShot.KBcontrols = false;
        }
    }
}