using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public int sceneIndex = 1;
    public GameObject helpMenu;

    private void Start()
    {
        helpMenu.SetActive(false);
    }

    public void Play()
    {
        SceneManager.LoadSceneAsync(sceneIndex);
    }
    public void Help()
    {
        helpMenu.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
