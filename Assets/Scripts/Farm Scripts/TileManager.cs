using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class TileManager : MonoBehaviour
{
    [SerializeField] private Tilemap interactableMap;
    [SerializeField] private Tilemap Ground;

    [SerializeField] private Tile hiddenInteractableTile;
    [SerializeField] private Tile interactedTile;
    //[SerializeField] private Tile fullGrownTile;
    [SerializeField] private Tile plotTile;
    [SerializeField] private Tile plantReadyTile;

    //[SerializeField] private Player plantCounter;
    //Player.GlobalPlant plantCounter;
    //Player.GlobalPlant plantReady;

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
//Booleans ------------------------------------------------------------------------
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
        TileBase tile = Ground.GetTile(position);

        if(tile != null)
        {
            if(tile.name == "plant_ready")
            {
                return true;
            }
        }

        return false;
    }
//tile setting --------------------------------------------------------------------------------------

    public void PlantSeed(Vector3Int position)
    {
        Ground.SetTile(position, interactedTile);
        interactableMap.SetTile(position, hiddenInteractableTile);

        
       
    }

public void PluckPlant(Vector3Int position)
    {
            Player.plantCounter = 0;
            interactableMap.SetTile(position, hiddenInteractableTile);
            Ground.SetTile(position, plotTile);
            
    }


    public void SetPlantFullGrown(Vector3Int position)
    {
        if(Player.plantReady == true)
        {
            Ground.SetTile(position, plantReadyTile);
        }
    }

}
