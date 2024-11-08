using UnityEngine;
using UnityEngine.SceneManagement; // For loading scenes

public class PlayButtonScript : MonoBehaviour
{
    public void PlayGame(string Level)
    {
        // Load the Level One scene (replace "Level One" with your actual scene name)
        SceneManager.LoadScene(Level);
    }
}
