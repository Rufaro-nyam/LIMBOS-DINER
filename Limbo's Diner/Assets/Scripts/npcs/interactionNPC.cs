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


    public void Interact()
    {
        Debug.Log ("Interact");
        dialoguePrompt.StartDialogue();
        dialoguePrompt.nextLine();
        dialoguePrompt.gameObject.SetActive(true);

        TimerCountdown.gameObject.SetActive(true);


    }








    


}


