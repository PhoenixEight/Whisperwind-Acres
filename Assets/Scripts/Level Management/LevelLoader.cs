using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public static LevelLoader instance;
    public string LevelName;

    public void LoadScene()
    {
        SceneManager.LoadScene(LevelName, LoadSceneMode.Single);
    }

}