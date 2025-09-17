using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class interactionNPC : MonoBehaviour
{

    public void Interact()
    {
        Debug.Log ("Interact");
        dialoguePrompt.StartDialogue();
        dialoguePrompt.gameObject.SetActive(true);
    }
    
    public dialoguePrompt dialoguePrompt;

    //void OnTriggerEnter(Collider NPC)
   // {
        //if (NPC.CompareTag("Player"))
       // {
            //if (dialoguePrompt != null && Input.GetKeyDown(KeyCode.E))
           // {
                //dialoguePrompt.StartDialogue();
               // Debug.Log ("Interact");
          //  }
       // }
   // }

}


