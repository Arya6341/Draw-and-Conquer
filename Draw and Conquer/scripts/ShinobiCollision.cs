using UnityEngine;
using UnityEngine.SceneManagement;

public class ShinobiCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Flag"))
        {
            // Load the "Next Level" scene when the player reaches the flag
            SceneManager.LoadScene("Next Level");
        }
    }
}
