using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class interactionItro : MonoBehaviour
{
    public dialogueIntro dialogueIntro;

    public void Interact()
    {
        Debug.Log("interact2");
        dialogueIntro.StartDialogue();
        dialogueIntro.nextLine();
        dialogueIntro.gameObject.SetActive(true);
    }
}
