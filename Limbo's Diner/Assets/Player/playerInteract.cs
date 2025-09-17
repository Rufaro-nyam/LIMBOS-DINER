using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;


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
