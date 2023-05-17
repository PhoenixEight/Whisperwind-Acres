using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageableCharacter : MonoBehaviour, IDamageable
{
    public GameObject healthText;
    public bool disableSimulation = false;
    public bool isInvincibleEnabled = false;
    public float invincibilityTime = 0.25f;
    Animator animator;
    Rigidbody2D rb;
    Collider2D physicsCollider;

    public bool isLiving = true;
    bool isAlive = true;
    private float invincibleTimeElapsed = 0f;
    public float Health{
        set{
            if(value < _health)
            {
                animator.SetTrigger("damaged");
                RectTransform textTransform = (RectTransform) Instantiate(healthText).GetComponent<RectTransform>();
                textTransform.transform.position = Camera.main.WorldToScreenPoint(gameObject.transform.position);

                Canvas canvas = GameObject.FindObjectOfType<Canvas>();
                textTransform.SetParent(canvas.transform);
            }

            _health = value;
            print(value);

            if(_health <= 0)
            {
                Defeated();
                Targetable = false;
                isLiving = false;
            }
        }
        get{
            return _health;
        }
    }

    public bool Targetable { get { return _targetable; }
    set {
        _targetable = value;

        if(disableSimulation)
        {
            rb.simulated = false;
        }

        physicsCollider.enabled = value;
    } }

    public bool Invincible { get { return _invincible; }
    set {
        _invincible = value;

        if(Invincible == true)
        {
            invincibleTimeElapsed = 0f;
        }
    } }

    float _health = 10;
    bool _targetable = true;

    public bool _invincible = false;

    public void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("isAlive", isAlive);

        rb = GetComponent<Rigidbody2D>();
        physicsCollider = GetComponent<Collider2D>();
    }

    public void OnHit(float damage, Vector2 knockback)
    {
        if(!Invincible)
        {
            Health -= damage;
            rb.AddForce(knockback);
            //Debug.Log("Force: " + knockback);

            if(isInvincibleEnabled)
            {
                Invincible = true;
            }
        }
    }

    public void OnHit(float damage)
    {
        if(!Invincible)
        {
            Health -= damage;

            if(isInvincibleEnabled)
            {
                Invincible = true;
            }
        }
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

    public void FixedUpdate()
    {
        invincibleTimeElapsed += Time.deltaTime;

        if(invincibleTimeElapsed > invincibilityTime)
        {
            Invincible = false;
        }
    }
}
