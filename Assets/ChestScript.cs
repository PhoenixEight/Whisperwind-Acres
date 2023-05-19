using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestScript : MonoBehaviour
{
    public GameObject visualCue;
    public InventoryManager chest;
    public UI_Manager ui;
    
    private void Awake()
    {
        chest = GetComponent<InventoryManager>();
        ui = GetComponent<UI_Manager>();
    }

     void OnTriggerStay2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if(player){
            if(Input.GetKeyDown(KeyCode.E))
            {
                ui.GetComponent<UI_Manager>().OpenChest();
                Debug.Log("E key pressed");
            }
        }

    }
/*
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            ui.OpenChest();
        }
    }
    */
}
