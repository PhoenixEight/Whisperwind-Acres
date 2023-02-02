using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalLoader : MonoBehaviour
{
    [SerializeField] private GameObject visualCue;
    public bool playerInRange;
    
    public string LevelName;

    public Animator animator;

    public void Fade()
    {
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(LevelName, LoadSceneMode.Single);
    }

    private void Start()
    {
        playerInRange = false;
        visualCue.SetActive(false);
    }

    /*void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Load next level");
            SceneManager.LoadScene(LevelName,LoadSceneMode.Single);
        }
    }*/

    private void Update()
    {
        
        if (playerInRange == true)
        {
            visualCue.SetActive(true);

            if (Input.GetKeyDown("e"))
            {
                Debug.Log("E Pressed");
                //LoadPanel();
                Fade();
                //SceneManager.LoadScene(LevelName, LoadSceneMode.Single);
            }
        }

        else
        {
            visualCue.SetActive(false);
        }
        
        
    }



    public IEnumerator FadeBlackOutSquare(bool fadeToBlack = true, int fadeSpeed = 5)
    {
        yield return new WaitForEndOfFrame();
    }


    /*private int LoadPanel()
    {
        this.GetComponent<MeshRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
        yield return new WaitForSeconds(5);
    }*/

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            playerInRange = false;
        }
    }
}
