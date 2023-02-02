using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DDOL : MonoBehaviour
{
    public static DDOL instance;

    private void Awake()
    {
        if (DDOL.instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        //else if (instance != null) Destroy(gameObject);
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
}