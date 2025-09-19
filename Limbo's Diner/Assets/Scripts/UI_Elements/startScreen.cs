using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class startScreen : MonoBehaviour
{
    public void playGame()
    {
        SceneManager.LoadSceneAsync("Main_cooking_scene");

    }
}
