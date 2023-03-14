using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public CollectableType type;
    public Sprite icon;
    //Player walks into collectable
    //add collectable to player
    //delete collectable from the screen

    private void OnTriggerEnter2D(Collider2D collision){

        Player player = collision.GetComponent<Player>();

        if(player)
        {
            player.inventory.Add(this);
            Destroy(this.gameObject);
        }
    }

}

public enum CollectableType
{
    NONE, SEED
}
