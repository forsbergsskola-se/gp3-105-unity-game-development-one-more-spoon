using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void ChangeScene()
    {
         UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
    }

    public void BackToMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }

    public void AccessInstructions()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Instructions");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
   
}
