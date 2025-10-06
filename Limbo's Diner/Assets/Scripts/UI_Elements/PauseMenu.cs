using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static bool is_paused = false;
    public GameObject pause_ui;
    public GameObject sensetivity_ui;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            if (is_paused) 
            {
                resume();
            }
            else 
            {
                pause();
            }
        
        }
    }

    public void resume() 
    {
        pause_ui.SetActive(false);
        Time.timeScale = 1f;
        is_paused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void pause() 
    {
        pause_ui.SetActive(true);
        Time.timeScale = 0f;
        is_paused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void restart() 
    {
        SceneManager.LoadSceneAsync("Main_cooking_scene");
    }

    public void main_menu() 
    {
        SceneManager.LoadSceneAsync("Main Menu");
    }

    public void activate_senetivity() 
    {
        sensetivity_ui.SetActive(true);
        pause_ui.SetActive(false);
    }

    public void return_to_pause() 
    {
        sensetivity_ui.SetActive(false);
        pause_ui.SetActive(true);
    }
}

