using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneController
{ 
    static int currentSceneIndex = 0; 

    public static void Restart()
    {
        SceneManager.LoadScene(currentSceneIndex);
    }

    public static void LoadNextScene()
    {
        SceneManager.LoadScene(++currentSceneIndex);
    }
}
