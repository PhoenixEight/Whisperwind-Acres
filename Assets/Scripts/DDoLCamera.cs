using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DDoLCamera : MonoBehaviour
{

    private static bool retainCamera;

    // Start is called before the first frame update
    void Start()
    {

        //Retain on Load of New Scene
        if (!retainCamera)
        {
            retainCamera = true;
            DontDestroyOnLoad(transform.gameObject);
            Debug.Log("Camera Loaded");
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /*private void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        // Retrieve the name of this scene.
        string sceneName = currentScene.name;

        if (sceneName == "Menu1")
        {
            Destroy(gameObject);
        }
    }*/
}