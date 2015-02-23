using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour
{
    public float volume = 1;

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
    }