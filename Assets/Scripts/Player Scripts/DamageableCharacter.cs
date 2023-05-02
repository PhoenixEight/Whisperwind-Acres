using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageableCharacter : MonoBehaviour, IDamageable
{
    Animator animator;
    Rigidbody2D rb;
    Collider2D physicsCollider;

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
                Targetable = false;
            }
        }
        get{
            return _health;
        }
    }

    public bool Targetable { get { return _targetable; }
    set {
        _targetable = value;

        //rb.simulated = value;
        physicsCollider.enabled = value;
    } }

    public float _health = 10;
    public bool _targetable = true;

    public void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("isAlive", isAlive);

        rb = GetComponent<Rigidbody2D>();
        physicsCollider = GetComponent<Collider2D>();
    }

    public void OnHit(float damage, Vector2 knockback)
    {
        //Debug.Log("Plant hit for " + damage);
        Health -= damage;

        rb.AddForce(knockback);
        //Debug.Log("Force: " + knockback);
    }

    public void OnHit(float damage)
    {
        //Debug.Log("Plant hit for " + damage);
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

    public void OnObjectDestroyed()
    {
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        
    }
}
