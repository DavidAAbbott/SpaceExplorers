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
        if(isOn == false)
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

    public void NumberOfPlayers(bool p2)
    {
        player2 = p2;
    }
}