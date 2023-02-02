using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour
{
    PlayerHealth playerHealth;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player" && LevelManager.instance.playerHealth != LevelManager.instance.playerMaxHealth)
        {
            Debug.Log("Player Healed");
            playerHealth = collider.gameObject.GetComponent<PlayerHealth>();
            playerHealth.UpdateHealth(+30);
            Destroy(this.gameObject);

        }
    }
}
