using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public InventoryManager inventory;

    public Vector3Int plantPosition;

    public Item commonScythe = GameManager.instance.itemManager.GetItemByName("Common Scythe");
    public Item uncommonScythe = GameManager.instance.itemManager.GetItemByName("Uncommon Scythe");
    public Item rareScythe = GameManager.instance.itemManager.GetItemByName("Rare Scythe");
    float CommonSeedChances = 0.0f;
    


    public static int plantCounter = 0;
    /*
    public static int plantCounter1 = 0;
    public static int plantCounter2 = 0;
    public static int plantCounter3 = 0;
    public static int plantCounter4 = 0;
    public static int plantCounter5 = 0;
    public static int plantCounter6 = 0;
    public static int plantCounter7 = 0;
    public static int plantCounter8 = 0;
    */
    //public static bool plantReady = true;

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
            GameManager.instance.tileManager.SetPlantFullGrown(plantPosition);
            //plantReady = true;
            
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
                        float CommonSeedChances = Random.Range(1.0f, 100.0f);
                        Debug.Log("This is the CommonSeedChances: " + CommonSeedChances);
                        if(CommonSeedChances > 90.0f)
                        {
                            
                            inventory.Add("Backpack", rareScythe);
                        }
                        else if(CommonSeedChances > 60.0f )
                        {
                            inventory.Add("Backpack", uncommonScythe);
                        }
                        else{
                            inventory.Add("Backpack", commonScythe);
                        }
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
