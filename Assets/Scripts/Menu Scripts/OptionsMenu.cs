using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    public void SetVolume (float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }

    public void SetQuality (int quality)
    {
        QualitySettings.SetQualityLevel(quality);
    }

    public void SetFullscreen (bool fullscreen)
    {
        Screen.fullScreen = fullscreen;
    }

    public void Back()
    {
        SceneManager.LoadScene("Menu");
    }
}
