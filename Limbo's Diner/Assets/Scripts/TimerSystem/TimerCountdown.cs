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
        timeRemaining -= Time.deltaTime;
        int minutes = Mathf.FloorToInt (timeRemaining/60);
        int seconds = Mathf.FloorToInt (timeRemaining % 60);

        timerText.text = string.Format ("{0:00}:{1:00}", minutes, seconds);

    }
}
