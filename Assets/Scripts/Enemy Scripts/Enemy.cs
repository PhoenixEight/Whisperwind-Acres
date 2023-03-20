using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Animator animator;

    bool isAlive = true;

    public float Health{
        set{
            if(value < _health)
            {
                animator.SetTrigger("damaged");
            }

            _health = value;
            print(value);

            if(_health <= 0)
            {
                Defeated();
            }
        }
        get{
            return _health;
        }
    }

    public float _health = 10;

    public void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("isAlive", isAlive);
    }

    void OnHit(float damage)
    {
        Health -= damage;
    }

    public void Defeated()
    {
        animator.SetBool("isAlive", false);
    }

    public void RemoveEnemy()
    {
        Destroy(gameObject);
    }
}
