using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverButtons : MonoBehaviour
{
    // This function will be called when the Main Menu button is clicked
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main menu"); // Replace "Main Menu" with the exact name of your main menu scene
    }

    // This function will be called when the Restart button is clicked
    public void RestartLevel()
    {
        // Reload the currently active level
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
