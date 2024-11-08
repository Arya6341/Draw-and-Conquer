using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public float levelTime = 60.0f; // Set the total level time here (in seconds)
    public Transform player; // Reference to the player object
    private float timeRemaining;

    private void Start()
    {
        // Initialize the remaining time
        timeRemaining = levelTime;
    }

    private void Update()
    {
        // Decrease the remaining time
        timeRemaining -= Time.deltaTime;

        // Check if the player falls below -15 in the y-axis
        if (player.position.y < -15)
        {
            TriggerGameOver();
        }

        // Check if time runs out
        if (timeRemaining <= 0)
        {
            TriggerGameOver();
        }
    }

    // Function to load the Game Over scene
    private void TriggerGameOver()
    {
        SceneManager.LoadScene("Game Over"); // Ensure "Game Over" matches the actual name of your Game Over scene
    }
}
