using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;

// Title: How To Talk To NPCs! (Or interact with any object, open doors, push buttons, Unity Tutorial)
// Author: Code Monkey
// Date Accessed: 17/09/2025
// Availability: https://www.youtube.com/watch?v=LdoImzaY6M4&t=1288s

public class playerInteract : MonoBehaviour
{
    public GameObject npc_dialogue;
    public GameObject intro_dialogue;
    public GameObject prompt;
    private bool dialogue_active = false;
    private float active_time = 5.0f;
    private void Update()
    {
        if (dialogue_active) 
        {
            active_time -= Time.deltaTime;
            if(active_time < 0) 
            {
                dialogue_active = false;
                npc_dialogue.SetActive(false);
            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            float interactRange = 6f;
            Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
            
            foreach (Collider collider in colliderArray)
            {
                if (collider.TryGetComponent (out interactionNPC interactionNPC))
                {
                    npc_dialogue.SetActive(true);
                    intro_dialogue.SetActive(false);
                    prompt.SetActive(false);
                    dialogue_active = true;
                    npc_dialogue.SetActive(true);
                    interactionNPC.Interact();
                    
                }
            }
        }
    }
}
