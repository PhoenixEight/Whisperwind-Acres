using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public float playerMaxHealth = 10f;
    public float playerHealth = 10f;

    public string LevelName;

    public HealthBarScript healthBar;

    private void Awake()
    {
        if (LevelManager.instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else if (instance != null) Destroy(gameObject);
    }

    private void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        // Retrieve the name of this scene.
        string sceneName = currentScene.name;

        if (sceneName == "Menu1")
        {
            Destroy(gameObject);
        }
    }

    public void LoadMenuScene()
    {
        SceneManager.LoadScene(LevelName, LoadSceneMode.Single);
    }

    public void GameOver()
    {
        Debug.Log("GameOver Called");
        UIManager _ui = GetComponent<UIManager>();
        if (_ui != null)
        {
            _ui.ToggleDeathPanel();
        }
    }

    public void ReloadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        //healthBar = GameObject.Find("Health Bar");

        healthBar.SetMaxHealth(LevelManager.instance.playerMaxHealth);
        healthBar.SetHealth(LevelManager.instance.playerHealth);
        //healthBar.SetHealth(10);
    }
}
