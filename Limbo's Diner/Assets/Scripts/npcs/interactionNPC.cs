using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;


public class interactionNPC : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI textComponent;
    public string[] dialogueLines;
    public float textSpeed;

    private int index;


    public void Interact()
    {
        //TESTING THAT INTERACTION WORKS, DELETE LATER
        Debug.Log ("Interact");
    }

    
    void Start ()
    {
        textComponent.text = string.Empty;
        StartDialogue();
    }

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

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in dialogueLines[index].ToCharArray())
        {   
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void nextLine()
    {
        if (index < dialogueLines.Length - 1)
        {
            index ++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }





}
