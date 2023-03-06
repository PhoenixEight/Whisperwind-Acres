using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
Animator animator;

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

    public void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Defeated()
    {
        animator.SetTrigger("Defeated");
    }

    public void RemoveEnemy()
    {
        Destroy(gameObject);
    }
}//1:20:55
