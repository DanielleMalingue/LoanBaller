using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneNav : MonoBehaviour
{
    // Function to load a scene by its name
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // Function to load a scene by its build index
    public void LoadScene(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
    }

    // Function to quit the application
    public void QuitApplication()
    {
        Application.Quit();
    }
}
