using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Item))]
public class RareScytheScript : MonoBehaviour//, IDataPersistence
{

    [SerializeField] private string id;

    /*
    [ContextMenu("Generate guid for id")]

    private bool collected = false;
    */
    private void GenerateGuid()
    {
        id = System.Guid.NewGuid().ToString();
    }
    

    private void OnTriggerEnter2D(Collider2D collision){

        Player player = collision.GetComponent<Player>();

        if(player)
        {
            Item item = GetComponent<Item>();

            if(item != null)
            {
                player.inventory.Add("Backpack", item);
                Destroy(this.gameObject);
                //collected = true;
            }
            
        }
    }

    /*
    public void LoadData(GameData data)
    {
        data.seedsCollected.TryGetValue(id, out collected);
        if(collected)
        {
            visual.gameObject.SetActive(false);
        }
    }

    public void SaveData(ref GameData data)
    {
        if(data.seedsCollected.ContainsKey(id))
        {
            data.seedsCollected.Remove(id);
        }

        data.seedsCollected.Add(id, collected);
    }
    */
}

