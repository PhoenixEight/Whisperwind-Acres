using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Farm scene");
        
        DataPersistenceManager.instance.NewGame();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}