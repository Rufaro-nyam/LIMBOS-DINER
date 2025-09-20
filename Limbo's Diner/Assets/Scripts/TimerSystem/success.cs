using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;


public class success : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI successText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       gameObject.SetActive(false); 
    }

}
