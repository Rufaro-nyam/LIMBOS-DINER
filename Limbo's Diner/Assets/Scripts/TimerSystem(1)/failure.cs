using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;


public class failure : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI failureText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObject.SetActive(false);
    }


}
