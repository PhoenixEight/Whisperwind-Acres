using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour
{
    public GameObject tutorialPanel;
    public GameObject pausePanel;
    public void Awake(){
        tutorialPanel.SetActive(false);
        //pausePanel.SetActive(false);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Title Screen");
    }

    public void Tutorial()
    {
        if(!tutorialPanel.activeSelf)
        {
            tutorialPanel.SetActive(true);
            pausePanel.SetActive(false);
        }
        else{
            tutorialPanel.SetActive(false);
            
        }
    }

    public void BackToPause()
    {
        
            tutorialPanel.SetActive(false);
            pausePanel.SetActive(true);
        
        
    }


}
