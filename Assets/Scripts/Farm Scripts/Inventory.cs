using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Inventory
{
    [System.Serializable]
    public class Slot{
        public string itemName;
        public int count; //keeps track of number of items in that slot
        public int maxAllowed;

        //experiment:
        public static bool seedExists;

        public Sprite icon;

        public Slot(){
            itemName = "";
            count = 0;
            maxAllowed = 1;
            
        }

        public bool IsEmpty
        {
            get
            {
                if(itemName == "" && count == 0)
                {
                    return true;
                }

                return false;
            }
        }

        public bool CanAddItem(string itemName){
            if(this.itemName == itemName && count < maxAllowed){
                return true;
            }
            return false;
        }

        public void AddItem(Item item){
            this.itemName = item.data.itemName;
            this.icon = item.data.icon;
            count++;
        }

        public void AddItem(string itemName, Sprite icon, int maxAllowed){
            this.itemName = itemName;
            this.icon = icon;
            count++;
            this.maxAllowed = maxAllowed;
        }

        public void RemoveItem()
        {
            if(count> 0)
            {
                count--;

                if(count == 0)
                {
                    icon = null;
                    itemName = "";
                }
            }
        }
    }

    public List<Slot> slots = new List<Slot>();

    public Inventory(int numSlots){

        for(int i = 0; i < numSlots; i++){
            Slot slot = new Slot();
            slots.Add(slot);
        }
    }

    public void Add(Item item){
        foreach(Slot slot in slots){
            if(slot.itemName == item.data.itemName && slot.CanAddItem(item.data.itemName)){
                slot.AddItem(item);
                return;
            }
        }

        foreach(Slot slot in slots){
            if(slot.itemName == ""){
                slot.AddItem(item);
                return;
            }
        }
    }

    public void Remove(int index)
    {
        slots[index].RemoveItem();
    }
    public void Remove(int index, int numToRemove)
    {
        if(slots[index].count >= numToRemove)
        {
            for(int i = 0; i < numToRemove; i++)
            {
                Remove(index);
            }
        }
    }

    public void MoveSlot(int fromIndex, int toIndex, Inventory toInventory, int numToMove = 1)
    {
        Slot fromSlot = slots[fromIndex];
        Slot toSlot = toInventory.slots[toIndex];

        if(toSlot.IsEmpty || toSlot.CanAddItem(fromSlot.itemName))
        {
            for(int i = 0; i < numToMove; i++)
            {
                toSlot.AddItem(fromSlot.itemName, fromSlot.icon, fromSlot.maxAllowed);
                fromSlot.RemoveItem();
            }
        }
    }

public void RemoveSeed()
    {
        foreach(Slot slot in slots)
        {
            if(slot.itemName == "Common Seeds"){
                slot.RemoveItem();
                //Debug.Log("In slot: " + slot + " There is item name" + slot.itemName);
            }
        }
    }

public void CheckSeed()
{
    foreach(Slot slot in slots)
        {
            if(slot.itemName == "Common Seeds"){
                Slot.seedExists = true;
                //Debug.Log("In slot: " + slot + " There is item name" + slot.itemName);
            }
            else
              Slot.seedExists = false;
        }
}

/*
public void PluckPlantItem(Item item)
{
    foreach(Slot slot in slots)
    {
        
        if(slot.IsEmpty)
        {
            slot.AddItem(item);
        }
        //one of these 2 might work
        
        if(slot.itemName == "")
        {
            slot.Add(item);
        }
        

        
    }
    
}
*/



}//end inventory.cs
