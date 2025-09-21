using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class dialogueBox : MonoBehaviour
{
    public dialoguePrompt dialoguePrompt;
    public interactionNPC interactionNPC;

    void Start()
    {
        gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            gameObject.SetActive(true);
        }
    }
}
