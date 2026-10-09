using UnityEngine;
using TMPro;

// This is the timer class.
// This class serves the purpose to make the function of the timer
// on the left-hand side decrease in time, and reset if need be. 
public class Timer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public TextMeshProUGUI timeDisplay;
    public float timer = 5f;
    private bool timeIsRunning = false;
    void Start()
    {
        DisplayTime(timer);
    }

    // Update is called once per frame
    void Update()
    {
        TimerDecrease();
    }

    void TimerDecrease()
    {
        while (timeIsRunning)
        {
            if (timer > 0)
            {
                timer -= 0.5f * Time.deltaTime;
                DisplayTime(timer);
            }
            else
            {
                Debug.Log("Time to shoot!");
                DisplayTime(timer);
                timeIsRunning = false;
                TimerEnd();
            }
        }
    }

    void DisplayTime(float currentTime)
    {
        // If the time is 0. Then the time will be dished out.
        if (currentTime < 0)
        {
            currentTime = 0;
        }

        // This will display the time live.
        timeDisplay.text = currentTime.ToString();

    }

    void TimerEnd()
    {
        Debug.Log("Shooting Time...");
    }
}
