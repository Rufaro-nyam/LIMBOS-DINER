using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class startScreen : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void playGame()
    {
        
        SceneManager.LoadSceneAsync("Main_cooking_scene");
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
