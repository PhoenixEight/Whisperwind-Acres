using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{

    public string Level1;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
         {
        SceneManager.LoadScene(Level1,LoadSceneMode.Single);

         }
    }    
   
   
}
