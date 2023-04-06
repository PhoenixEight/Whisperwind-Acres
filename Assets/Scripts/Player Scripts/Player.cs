using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public InventoryManager inventory;
    

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
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Vector3Int position = new Vector3Int((int)transform.position.x,(int)transform.position.y, 0);
            //original
            if(GameManager.instance.tileManager.IsInteractable(position))
            {
                //item is called "Common Seeds"
                        inventory.RemoveSeed("Toolbar");
                        Debug.Log("Tile is interactable");
                        GameManager.instance.tileManager.SetInteracted(position);
                        
                        
            }
        }
    }
}
