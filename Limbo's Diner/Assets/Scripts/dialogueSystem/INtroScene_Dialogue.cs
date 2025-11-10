using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class INtroScene_Dialogue : MonoBehaviour
{

    public GameObject DialogueBox;
    [SerializeField] public TextMeshProUGUI line1;
    [SerializeField] public TextMeshProUGUI line2;
    [SerializeField] public TextMeshProUGUI line3;
    [SerializeField] public TextMeshProUGUI line4;
    [SerializeField] public TextMeshProUGUI line5;
    [SerializeField] public TextMeshProUGUI line6;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DialogueBox.gameObject.SetActive(true);
        line1.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
