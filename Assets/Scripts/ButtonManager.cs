using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public string sceneName;
    // Start is called before the first frame update
    public void OnClick()
    {
        LoadScene();
    }
    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
