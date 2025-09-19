using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class burgerTimer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float burgerTimeRemaining;

    public burgerTimer burgerCountdown;

    void Start()
    {
        burgerCountdown.gameObject.SetActive(false);
    }

    public void Interact()
    {
        Debug.Log("Burger Timer Started");
    }
    
    void Update()
    {

        if (burgerTimeRemaining > 0)
        {
            burgerTimeRemaining -= Time.deltaTime;
        }
        else if (burgerTimeRemaining < 0)
        {
            burgerTimeRemaining = 0;
            timerText.color = Color.red;
            // add sound effect??
        }


        int minutes = Mathf.FloorToInt (burgerTimeRemaining/60);
        int seconds = Mathf.FloorToInt (burgerTimeRemaining % 60);

        timerText.text = string.Format ("{0:00}:{1:00}", minutes, seconds);


    }
}
