using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Manager : MonoBehaviour
{
    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadSceneAsync(sceneIndex);
    }

    public void LoadMainMenuDelayed(float delay)
    {
        Invoke("LoadMainMenu", delay);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
