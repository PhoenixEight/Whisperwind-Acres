using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StateManager : MonoBehaviour
{
    //public static StateManager instance;

    public HealthBarScript healthBar;

    private void Awake()
    {
        //healthBar = GameObject.GetComponent < HealthBarScript() >();
        //healthBar = GameObject.Find("Health Bar");
    }

   

    public void ReloadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        //healthBar = GameObject.Find("Health Bar");

        healthBar.SetMaxHealth(LevelManager.instance.playerMaxHealth);
        healthBar.SetHealth(LevelManager.instance.playerHealth);
        //healthBar.SetHealth(10);
    }

    public void ChangeSceneByName(string name)
    {
        if (name != null)
        {
            SceneManager.LoadScene(name);
        }
    }
}
