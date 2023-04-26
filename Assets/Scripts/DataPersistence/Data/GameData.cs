using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class GameData
{
   public int money;
   public Vector3 playerPosition;

   public Dictionary<string, bool> seedsCollected;

   //The values defined in this cconstructor will be the default values
   // the game starts with when there's no data to load
   public GameData()
   {
        this.money = 0;
         playerPosition = Vector3.zero;
         seedsCollected = new Dictionary<string, bool>();
   }
}
