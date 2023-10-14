using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class GoalMenuScript : MonoBehaviour
{
    //public AudioMixer audioMixer;
    public GameObject goalMenuUI;

    public void Goal()
    {
        goalMenuUI.SetActive(true);
        Time.timeScale = 0.01f;
        //audioMixer.SetFloat("Volume", -10.0f);
    }

    public void Retry()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Tutorial");
    }

    public void LoadMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }
}
