using System.Collections;
using UnityEngine;
using TMPro; // Import TextMesh Pro namespace

public class Timer : MonoBehaviour
{
    public float WaitSec;
    public TextMeshProUGUI text; // Use TextMeshProUGUI instead of Text
    private bool isTimerRunning = false;

    private void Start()
    {
        StartCoroutine(StartTimerAfterDelay(1f)); // Wait for 1 second before starting the timer
    }

    private void FixedUpdate()
    {
        if (isTimerRunning && WaitSec > 0)
        {
            WaitSec -= Time.fixedDeltaTime;
            int WaitSecInt = Mathf.FloorToInt(WaitSec);  // Convert to int
            text.text = WaitSecInt.ToString();  // Update the TMP text component

            if (WaitSec <= 0)
            {
                WaitSec = 0;  // Clamp to 0
                isTimerRunning = false;  // Stop the timer
                text.text = "0";  // Ensure the text displays 0
            }
        }
    }

    // Coroutine to start the timer after a 1-second delay
    private IEnumerator StartTimerAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        isTimerRunning = true;  // Start the timer after the delay
    }
}
