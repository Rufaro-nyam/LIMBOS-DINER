using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;


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
    public GameObject win_text;

    //SCORING SYSTEM
    public bool single_dish = true;
    public Score_display score;

    //END LEVEL
    private Animator anim;

    //SOUND
    private AudioSource clock_sound;

    //ENDING
  
    private bool ending = false;
    
    private bool can_play_sound = true;
    public bool started = false;
    public Queue queue;
    [SerializeField] Image end_pic;

    void Start()
    {
        
        clock_sound = GetComponent<AudioSource>();
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
        /*Color curent_color = end_pic.tintColor;

        if (ending && curent_color.a <= 1f)
        {
            curent_color.a += Time.deltaTime;
        }
        end_pic.tintColor = curent_color;
        if(end_pic.tintColor.a >= 0.9f)
        {
            quit_to_menu();
        }*/

        if (burgerTime > 0)
        {
            queue.started = true;
            burgerTime -= Time.deltaTime;
        }
        else if (burgerTime < 0)
        {
            burgerTime = 0;
            burgerTimer.color = Color.red;
            failure.gameObject.SetActive(true);
            clock_sound.Stop();
            foreach (TestNpc n in npcs)
            {
                n.lose();
                anim.SetTrigger("End");
                queue.lose();
            }
            // add sound effect later

        }

        if(single_dish && burgerTime <= 20)
        {
            play_sound();
        }
        if(single_dish == false && burgerTime <= 30)
        {
            play_sound();
        }


        int minutes = Mathf.FloorToInt (burgerTime/60);
        int seconds = Mathf.FloorToInt (burgerTime % 60);

        burgerTimer.text = string.Format ("{0:00}:{1:00}", minutes, seconds);


    }

    public void win() 
    {
        win_text.SetActive(true);
        anim.SetTrigger("End");
        foreach (TestNpc n in npcs)
        {
            
            //print("ended");
        }
        //anim.SetTrigger("End");
        print(burgerTime);
    }

    public void deduce_score()
    {
        clock_sound.Stop();
        can_play_sound = true;
        print(burgerTime);
        if (single_dish)
        {
            if(burgerTime >= 40)
            {
                print("great!");
                score.show_great();

            }
            else if(burgerTime >= 20 && burgerTime <= 39)
            {
                print("Meh");
                score.show_satisfied();
            }
            else
            {
                print("Close Cut");
                score.show_tardy();
            }
        }
        if(single_dish == false)
        {
            if (burgerTime >= 90)
            {
                print("great!");
                score.show_great();

            }
            else if (burgerTime <= 60 && burgerTime >= 39)
            {
                print("Meh");
                score.show_satisfied();
            }
            else
            {
                print("Close Cut");
                score.show_tardy();
            }
        }
    }
    public void quit_to_menu() 
    {
        SceneManager.LoadSceneAsync("Main Menu");
    }

    public void play_sound()
    {
        if (can_play_sound)
        {
            clock_sound.Play();
            can_play_sound = false;
        }
    }

    public void win_to_menu()
    {
        anim.SetTrigger("End");
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

