using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class TestNpc : MonoBehaviour
{
    
    public GameObject text1;
    public GameObject text2;
    private bool satisfied = false;
    private bool dissatisfied = false;
    public GameObject next_npc;
    public ParticleSystem win_particles;

    //REFERENCES
    public TimerCountdown TimerCountdown;
    public success success;

    public bool last_npc;
    public TimerCountdown timer;
    private bool can_win = true;
    private bool can_deduce_score = true;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        text1.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (satisfied)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 1f * Time.deltaTime, transform.position.z);
            if(last_npc && can_win) { win_game(); can_win = false; }
            if (can_deduce_score)
            {
                timer.deduce_score();
                can_deduce_score = false;
            }
        }
        if (dissatisfied)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 1f * Time.deltaTime, transform.position.z);
        }

        
    }

    public void win_game() 
    {
        timer.win();
    }

    public void win() 
    {
        win_particles.Play();
        text1.SetActive(false);
        text2.SetActive(true);
        satisfied = true;
        next_npc.SetActive(true);

        //STOP COUNTDOWN
        TimerCountdown.gameObject.SetActive(false);
        Debug.Log("Burger Countdown Stopped");

        //DISPLAY TEXT = LATER CHANGE TO REPORT
        //success.gameObject.SetActive(true);
    }

    public void lose() 
    {
        dissatisfied = true;
    }
}
