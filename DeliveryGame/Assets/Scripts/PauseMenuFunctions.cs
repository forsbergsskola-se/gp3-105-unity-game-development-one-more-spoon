using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenuFunctions : MonoBehaviour
{

    public void RestartGame()
    {
        
    }

    public void Settings()
    {
        
    }
    
    public void MainMenu()
    {
        SceneManager.LoadScene(sceneName:"MainMenu");
    }
    
}
