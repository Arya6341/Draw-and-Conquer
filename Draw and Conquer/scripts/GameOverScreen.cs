using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public GameObject gameOverScreen;  
    public GameObject player;  
    public Transform playerSpawnPoint;  
    public TextMeshProUGUI timerText;  
    public float WaitSec = 60f;  
    private bool isGameOver = false;

    void Start()
    {
        
        RespawnPlayer();
    }

    void Update()
    {
        
        if (!isGameOver && WaitSec > 0)
        {
            WaitSec -= Time.deltaTime;
            int minutes = Mathf.FloorToInt(WaitSec / 60);
            int seconds = Mathf.FloorToInt(WaitSec % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

            if (WaitSec <= 0)
            {
                TriggerGameOver();
            }
        }

        
        if (player.transform.position.y < -10f) 
        {
            TriggerGameOver();
        }
    }

   
    void TriggerGameOver()
    {
        isGameOver = true;
        gameOverScreen.SetActive(true);  
        Time.timeScale = 0f;  
    }

    
    public void RespawnPlayer()
    {
        player.transform.position = playerSpawnPoint.position;
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;  
        WaitSec = 60f;  
        isGameOver = false;
        gameOverScreen.SetActive(false); 
        Time.timeScale = 1f;  
    }

   
    public void RestartGame()
    {
        RespawnPlayer();  
    }


    public void LoadMainMenu()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene("MainMenu");  
    }
}
