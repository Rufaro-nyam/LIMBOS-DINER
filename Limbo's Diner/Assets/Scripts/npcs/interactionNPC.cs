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

    public GameObject fish_dia;
    public GameObject hotdog_dia;

    public bool fish = false;
    public bool hotdog = false;

    public TestNpc TestNpc;


    public void Interact()
    {
        Debug.Log ("Interact");
        dialoguePrompt.StartDialogue();
        dialoguePrompt.nextLine();
        dialoguePrompt.gameObject.SetActive(true);

        
        // STARTS TIMER
        TimerCountdown.gameObject.SetActive(true);
        TimerCountdown.burgerTime = 90;

        if (fish) { fish_dia.SetActive(true); } else { return; }
        if (hotdog) { hotdog_dia.SetActive(true); } else { return; }
        StartCoroutine(disable());
    }

    private IEnumerator disable() 
    {
        yield return new WaitForSeconds(5);
        fish_dia.SetActive(false);
        hotdog_dia.SetActive(false);
    }



}


