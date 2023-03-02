using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Health{
        set{
            health = value;
            if(health <= 0)
            {
                Defeated();
            }
        }
        get{
            return health;
        }
    }

    public float health = 10;

    public void Defeated()
    {
        Destroy(gameObject);
    }
}//1:20:55
