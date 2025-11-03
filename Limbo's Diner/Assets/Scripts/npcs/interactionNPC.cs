using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class interactionNPC : MonoBehaviour
{
    //REFERENCE FOR INTERACT
    public dialoguePrompt dialoguePrompt;

    //REFERENCE FOR TIMER
    public TimerCountdown TimerCountdown;
    [SerializeField] TextMeshProUGUI burgerTimer;

    public GameObject fish_dia ;
    public GameObject hotdog_dia;
    public GameObject burger_dia;
    public GameObject hotdog_n_burger_dia;
    public GameObject burger_n_fishdish_dia;

    public bool fish ;
    public bool hotdog ;
    public bool burger ;
    public bool htd_n_brg;
    public bool brg_n_fshdsh;

    public bool single_dish;

    public TestNpc TestNpc;
    private bool can_start = true;
    public bool can_interact;




    public void Interact()
    {
        if (can_start && can_interact)
        {
            Debug.Log("Interact");
            dialoguePrompt.StartDialogue();
            dialoguePrompt.nextLine();
            dialoguePrompt.gameObject.SetActive(true);


            // STARTS TIMER
            TimerCountdown.gameObject.SetActive(true);
            if (single_dish) { TimerCountdown.burgerTime = 90; TimerCountdown.single_dish = true; }
            else { TimerCountdown.burgerTime = 150; TimerCountdown.single_dish = false; }


            if (burger)
            {
                StartCoroutine(disable());
                burger_dia.SetActive(true);
            }
            else if (fish)
            {
                StartCoroutine(disable());
                fish_dia.SetActive(true);
                print("fishdish i want");
            }
            else if (hotdog)
            {
                StartCoroutine(disable());
                hotdog_dia.SetActive(true);
                print("hotdog i want");
            }
            else if (htd_n_brg)
            {
                StartCoroutine(disable());
                hotdog_n_burger_dia.SetActive(true);
                print("hotdog and burger i want");
            }
            else if (brg_n_fshdsh)
            {
                StartCoroutine(disable());
                burger_n_fishdish_dia.SetActive(true);
                print("burger and fishdish i want");
            }
            else
            {
                return;
            }
            can_start = false;
        }



        
    }

    private IEnumerator disable() 
    {
        print("started");
        yield return new WaitForSeconds(5);
        burger_dia.SetActive(false);
        fish_dia.SetActive(false);
        hotdog_dia.SetActive(false);
        hotdog_n_burger_dia.SetActive(false);
        burger_n_fishdish_dia.SetActive(false);


        print("done");
    }



}


