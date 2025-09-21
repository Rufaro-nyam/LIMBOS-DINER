using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;

// Title: 5 Minute DIALOG SYSTEM in UNITY Tutorial
// Author: BMo
// Date Accessed: 17/09/2025
// Availability: https://www.youtube.com/watch?v=8oTYabhj248

public class dialoguePrompt : MonoBehaviour
{
    //DIALOGUE SYSTEM
    [SerializeField] public TextMeshProUGUI textComponent;
    public string[] dialogueLines;
    public float textSpeed;
    private int index;
    public GameObject dialogueBox;

    
    void Start ()
    {
        textComponent.text = string.Empty;
        dialogueBox.SetActive(false);

    }

    //AUTO COMPLETE TEXT WHEN LEFT CLICKING
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == dialogueLines[index])
            {
                nextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = dialogueLines[index];
            }
        }
    }

    public void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
        
    }

    //TURN EACH CHARACTER TO ARRAY, ALLOWS FOR ONE BY ONE TEXT APPEARING
    public IEnumerator TypeLine()
    {
        foreach (char c in dialogueLines[index].ToCharArray())
        {   
            index++;
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
            
        }
    }

    // ALLOWS MULTIPLE LINES OF TEXT
    public void nextLine()
    {
        gameObject.SetActive(true);
    }

}

