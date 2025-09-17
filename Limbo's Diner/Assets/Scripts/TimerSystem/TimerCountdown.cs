using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;


public class TimerCountdown : MonoBehaviour
{

    // FOR COUNTDOWN DISPLAY
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float timeRemaining;
    [SerializeField] TextMeshProUGUI burgerTimer;
    [SerializeField] float burgerTime;
    [SerializeField] TextMeshProUGUI fishTimer;
    [SerializeField] float fishTime;
    [SerializeField] TextMeshProUGUI hotdogTimer;
    [SerializeField] float hotdogTime;

    public dialoguePrompt dialoguePrompt;
    
   // public void burgerCountdown()
   // {
       // if (dialoguePrompt.gameObject.SetActive(true))
       // {
        //    burgerTimer.SetActive(true);

       // }
   // }

    
    
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

    //public void Pause()
    //{
        //pauseMenu.SetActive (true);
        //Time.timeScale = 0;

        //fix this
    //}

    //public void Resume()
    //{
        //pauseMenu.SetActive (fasle);
        //Time.timeScale = 1;

        // fix this
    //}
    

}

// reference everything here
