using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    Animator animator;
    Rigidbody2D rb;

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

        rb = GetComponent<Rigidbody2D>();
    }

    public void OnHit(float damage, Vector2 knockback)
    {
        Debug.Log("Plant hit for " + damage);
        Health -= damage;

        rb.AddForce(knockback);
        Debug.Log("Force: " + knockback);
    }

    public void OnHit(float damage)
    {
        Debug.Log("Plant hit for " + damage);
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
