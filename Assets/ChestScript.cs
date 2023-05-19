using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestScript : MonoBehaviour
{
    public GameObject visualCue;
    //public InventoryManager chest;
    public UI_Manager ui;
    public GameObject chestPanel;
    public GameObject toolslotPanel;
    public GameObject inventoryPanel;
    
    private void Awake()
    {
        //chest = GetComponent<InventoryManager>();
        //ui = GetComponent<UI_Manager>();
    }

     void OnTriggerStay2D(Collider2D collision)
    {
        //Player player = collision.GetComponent<Player>();
        if(collision.tag == "Player"){
            Debug.Log("Player near chest");
            if(Input.GetKeyDown(KeyCode.E))
            {
                ui.OpenChest();
                
                /*
                if(!chestPanel.activeSelf)
                {
                
                    ui.RefreshInventoryUI("Chest");
                    ui.RefreshInventoryUI("Backpack");
                    ui.RefreshInventoryUI("Toolslot");
                    //ui.OpenChest();
                    
                    chestPanel.SetActive(true);
                    toolslotPanel.SetActive(true);
                    inventoryPanel.SetActive(true);
                    //UIRefreshInventoryUI("Chest");
                
                }
                else
                {
                    
                    chestPanel.SetActive(false);
                    toolslotPanel.SetActive(false);
                    inventoryPanel.SetActive(false);
                    
                    ui.ToggleInventoryUI();
                }
                */
                
                
            }
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            chestPanel.SetActive(false);
            toolslotPanel.SetActive(false);
            inventoryPanel.SetActive(false);
        }
    }
    
}
