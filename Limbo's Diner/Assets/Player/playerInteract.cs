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
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            float interactRange = 3f;
            Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
            
            foreach (Collider collider in colliderArray)
            {
                if (collider.TryGetComponent (out interactionNPC interactionNPC))
                {
                    interactionNPC.Interact();
                }
            }
        }
    }
}
