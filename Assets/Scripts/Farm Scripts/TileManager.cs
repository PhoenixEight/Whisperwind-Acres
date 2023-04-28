using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class TileManager : MonoBehaviour
{
    [SerializeField] private Tilemap interactableMap;

    [SerializeField] private Tile hiddenInteractableTile;
    [SerializeField] private Tile interactedTile;
    [SerializeField] private Tile fullGrownTile;
    [SerializeField] private Tile plotTile;

    public Player plantCounter;
    public Player plantReady;

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

    public void SetInteracted(Vector3Int position)
    {
        interactableMap.SetTile(position, interactedTile);
       /* if(plantReady == true)
        {
            interactableMap.SetTile(position, plotTile);
            //plantCounter = 0;
        
        }
        else
        {
            interactableMap.SetTile(position, interactedTile);
        }
        */
    }

public void PluckPlant(Vector3Int position)
    {
        if(plantReady == true)
        {
            interactableMap.SetTile(position, hiddenInteractableTile);
            interactableMap.SetTile(position, plotTile);
            //plantCounter = 0;
        }
    }
}
