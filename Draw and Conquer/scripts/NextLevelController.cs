using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelController : MonoBehaviour
{
    // This method will be called when the "Next" button is pressed
    public void LoadNextLevel()
    {
        // Get the current active scene
        Scene currentScene = SceneManager.GetActiveScene();

        // Calculate the next scene's build index
        int nextSceneIndex = currentScene.buildIndex + 1;

        // Check if the next scene exists in the build settings
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            // Load the next scene
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.Log("No more levels to load. Game Completed!");
            // Optionally, load a game over or congratulatory scene here
        }
    }

    // This method will be called when the "Restart" button is pressed
    public void RestartCurrentLevel()
    {
        // Reload the current level
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
