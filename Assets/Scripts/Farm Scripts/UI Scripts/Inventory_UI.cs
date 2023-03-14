using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_UI : MonoBehaviour
{
    public GameObject inventoryPanel;

    public Player player;

    public List<Slot_UI> slots = new List<Slot_UI>();

    // Update is called once per frame
    //Checks if the user presses tab, will then call the toggle inventory function
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab)){
            ToggleInventory();
        }
    }
    //function for toggling the inventory visual
    public void ToggleInventory(){
        if(!inventoryPanel.activeSelf){
            inventoryPanel.SetActive(true);
            Setup();
        }
        else{
            inventoryPanel.SetActive(false);
        }
    }
    //sets up the visuals for collecting items
    void Setup()
    {
        if(slots.Count == player.inventory.slots.Count)
        {
            for(int i = 0; i < slots.Count; i++)
            {
                if(player.inventory.slots[i].type != CollectableType.NONE)
                {
                    slots[i].SetItem(player.inventory.slots[i]);
                }
                else
                {
                    slots[i].SetEmpty();
                }
            }
        }

    }
}