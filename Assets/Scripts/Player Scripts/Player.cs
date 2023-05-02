using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public InventoryManager inventory;

    public Vector3Int plantPosition;

    public static int plantCounter = 0;
    public static bool plantReady = true;

    private void Awake(){
        inventory = GetComponent<InventoryManager>();
        
    }

    public void DropItem(Item item)
    {
        Vector2 spawnLocation = transform.position;

        Vector2 spawnOffset = Random.insideUnitCircle * 2.5f;

        Item droppedItem = Instantiate(item, spawnLocation + spawnOffset, 
        Quaternion.identity);

        droppedItem.rb2d.AddForce(spawnOffset * .5f, ForceMode2D.Impulse);

    }

    public void DropItem(Item item, int numToDrop)
    {
        for(int i = 0; i < numToDrop; i++)
        {
            DropItem(item);
        }

    }


    

    private void Update()
    {
        if(plantCounter == 3)
        {
            plantReady = true;
            GameManager.instance.tileManager.SetPlantFullGrown(plantPosition);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Vector3Int position = new Vector3Int((int)transform.position.x,(int)transform.position.y, 0);
            
            //original
            if(GameManager.instance.tileManager.IsInteractable(position))
            {
                if(GameManager.instance.tileManager.IsPluckable(position))
                { 
                        GameManager.instance.tileManager.PluckPlant(position);
                        //inventory.Add("Backpack", "Common Scythe");
                        plantCounter = 0;
                
                }
                else{

                    inventory.CheckSeed("Toolbar");
                    if(Inventory.Slot.seedExists == true)
                    {
                        //item is called "Common Seeds"
                        inventory.RemoveSeed("Toolbar");
                        Debug.Log("Tile is interactable");
                        GameManager.instance.tileManager.PlantSeed(position);
                        plantPosition = new Vector3Int((int)transform.position.x,(int)transform.position.y, 0);

                    }
                }
                        
            }
        }
    }
}
