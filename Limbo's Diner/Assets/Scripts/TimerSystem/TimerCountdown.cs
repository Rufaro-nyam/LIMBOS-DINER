using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;


public class TimerCountdown : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float timeRemaining;
    

    // Update is called once per frame
    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else if (timeRemaining < 0)
        {
            timeRemaining = 0;
            timerText.color = Color.red;
            // add sound effect??
        }


        int minutes = Mathf.FloorToInt (timeRemaining/60);
        int seconds = Mathf.FloorToInt (timeRemaining % 60);

        timerText.text = string.Format ("{0:00}:{1:00}", minutes, seconds);

    }
}
