using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


// Title: Make a TIMER & COUNTDOWN in 5 minutes | Unity Tutorial for beginners
// Author: Rehope Games
// Date Accessed: 15/09/2025
// Availability: https://www.youtube.com/watch?v=POq1i8FyRyQ

public class TimerCountdown : MonoBehaviour
{

    // FOR COUNTDOWN DISPLAY
    [SerializeField] TextMeshProUGUI burgerTimer;
    [SerializeField] public float burgerTime;
    [SerializeField] TextMeshProUGUI fishTimer;
    [SerializeField] float fishTime;
    [SerializeField] TextMeshProUGUI hotdogTimer;
    [SerializeField] float hotdogTime;
    public TestNpc[] npcs;

    //REFERENCES
    public TestNpc TestNpc;
    public failure failure;

    //END LEVEL
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        //ONLY SHOWS WITH DIALOGUE
        if (Input.GetKeyDown(KeyCode.E))
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }

    }


    // Update is called once per frame
    public void Update()
    {

        if (burgerTime > 0)
        {
            burgerTime -= Time.deltaTime;
        }
        else if (burgerTime < 0)
        {
            burgerTime = 0;
            burgerTimer.color = Color.red;
            failure.gameObject.SetActive(true);
            foreach(TestNpc n in npcs) 
            {
                n.lose();
                anim.SetTrigger("End");
            }
            // add sound effect later

        }


        int minutes = Mathf.FloorToInt (burgerTime/60);
        int seconds = Mathf.FloorToInt (burgerTime % 60);

        burgerTimer.text = string.Format ("{0:00}:{1:00}", minutes, seconds);


    }

    public void quit_to_menu() 
    {
        SceneManager.LoadSceneAsync("Main Menu");
    }

    //public void Pause()
    //{
        //pauseMenu.SetActive (true);
        //Time.timeScale = 0;

        //add later
    //}

    //public void Resume()
    //{
        //pauseMenu.SetActive (fasle);
        //Time.timeScale = 1;

        // add later
    //}
    

}

