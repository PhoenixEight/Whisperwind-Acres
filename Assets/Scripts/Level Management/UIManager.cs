using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField] GameObject deathPanel;

    public void ToggleDeathPanel()
    {
        deathPanel.SetActive(!deathPanel.activeSelf);
        Debug.Log("Death Panel Activated");
    }

    /*private void Awake()
    {
        deathPanel = GameObject.Find("DeathPanel");
    }*/
}
