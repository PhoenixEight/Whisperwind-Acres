using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    public static HealthBarScript instance;

    public Slider slider;

    public void SetHealth(float health)
    {
        slider.value = health;
    }

    public void SetMaxHealth(float maxHealth)
    {
        slider.maxValue = maxHealth;
    }

    public float GetHealth()
    {
        return slider.value;
    }

    private void Awake()
    {
        if (HealthBarScript.instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else if (instance != null) Destroy(gameObject);
    }
}
