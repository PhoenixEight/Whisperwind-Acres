using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class TileManager : MonoBehaviour
{
    [SerializeField] private Tilemap interactableMap;
    [SerializeField] private Tilemap groundMap;
    [SerializeField] private Tilemap plantMap;

    [SerializeField] private Tile hiddenInteractableTile;
    [SerializeField] private Tile interactedTile;
    [SerializeField] private Tile fullGrownTile;
    [SerializeField] private Tile plotTile;


    void Start()
    {
        foreach(var position in interactableMap.cellBounds.allPositionsWithin)
        {
            TileBase tile = interactableMap.GetTile(position);

            if(tile != null && tile.name == "interactable_visible")
            {
                interactableMap.SetTile(position, hiddenInteractableTile);
            }
            
        }
    }

    public bool IsInteractable(Vector3Int position)
    {
        TileBase tile = interactableMap.GetTile(position);

        if(tile != null)
        {
            if(tile.name == "interactable")
            {
                return true;
            }
        }

        return false;
    }

    public bool IsPluckable(Vector3Int position)
    {
        TileBase tile = plantMap.GetTile(position);

        if(tile!= null)
        {
            if(tile.name == "plant_ready")
            {
                return true;
            }
        }
        return false;

    }

    public void PlantSeed(Vector3Int position)
    {
        //interactableMap.SetTile(position, interactedTile);
        
        plantMap.SetTile(position, interactedTile);
    }

public void PluckPlant(Vector3Int position)
    {
            
            interactableMap.SetTile(position, hiddenInteractableTile);
            plantMap.SetTile(position, null);
            //groundMap.SetTile(position, plotTile);
            //plantCounter = 0;
    }

    public void SetPlantFullGrown(Vector3Int position)
    {
        TileBase tile = plantMap.GetTile(position);

            if(tile.name == "sprout_tile")
            {
                interactableMap.SetTile(position, hiddenInteractableTile);
                plantMap.SetTile(position, fullGrownTile);
                
            }
        

    }
}
