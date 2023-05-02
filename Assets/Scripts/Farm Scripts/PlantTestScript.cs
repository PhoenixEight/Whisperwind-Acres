using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantTestScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision){

        Player player = collision.GetComponent<Player>();

        if(player)
        {
                Player.plantCounter++;

                Destroy(this.gameObject);
                
        }
    }
}
