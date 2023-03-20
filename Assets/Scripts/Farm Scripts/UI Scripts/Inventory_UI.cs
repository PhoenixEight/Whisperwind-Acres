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
            Refresh();
        }
        else{
            inventoryPanel.SetActive(false);
        }
    }
    //sets up the visuals for collecting items
    void Refresh()
    {
        if(slots.Count == player.inventory.slots.Count)
        {
            for(int i = 0; i < slots.Count; i++)
            {
                if(player.inventory.slots[i].itemName != "")
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

    public void Remove(int slotID)
    {
        Item itemToDrop = GameManager.instance.itemManager.GetItemByName(
            player.inventory.slots[slotID].itemName);
        if(itemToDrop != null)
        {
            player.DropItem(itemToDrop);
            player.inventory.Remove(slotID);
            Refresh();
        }
       
    }
}
