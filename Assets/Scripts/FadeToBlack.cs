using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeToBlack : MonoBehaviour
{
    public Animator animator;

    public string LevelName;

    public void Fade()
    {
        animator.SetTrigger("FadeOut");
    }
    
    public void OnFadeComplete()
    {
        SceneManager.LoadScene(LevelName, LoadSceneMode.Single);
    }

    /*blic string triggerName;

    public void LoadScene(string sceneName)
    {
        animator.SetTrigger(triggerName);
        StartCoroutine(WaitForAnimation());
    }

    IEnumerator WaitForAnimation()
    {
        yeild return new
WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        SceneManager.LoadScene(sceneName);
    }*/
}
