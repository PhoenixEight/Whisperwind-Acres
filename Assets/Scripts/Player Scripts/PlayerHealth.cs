using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{

    public HealthBarScript healthBar;

    // Start is called before the first frame update
    void Start()
    {
        healthBar.SetMaxHealth(LevelManager.instance.playerMaxHealth);
        healthBar.SetHealth(LevelManager.instance.playerHealth);
    }

    // Update is called once per frame
    public void UpdateHealth(float deltaHealth)
    {
        LevelManager.instance.playerHealth += deltaHealth;

        if (LevelManager.instance.playerHealth <= 0)
        {
            LevelManager.instance.playerHealth = 0;
            PlayerDied();
        }
        else if (LevelManager.instance.playerHealth >= LevelManager.instance.playerMaxHealth)
        {
            LevelManager.instance.playerHealth = LevelManager.instance.playerMaxHealth;
        }

        healthBar.SetHealth(LevelManager.instance.playerHealth);
    }

    private void PlayerDied()
    {
        LevelManager.instance.GameOver();
        gameObject.SetActive(false);
    }
}

