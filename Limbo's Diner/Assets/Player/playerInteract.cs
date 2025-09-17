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
            float interactRange = 1f;
            Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
            
        }
    }
}
