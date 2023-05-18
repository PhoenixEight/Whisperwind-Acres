using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float damage = 1;

    // const float m_dropChance = 1f / 1f;  // Set odds (1/X)

    // public GameObject collectable;

    // public Transform target;

    public float knockbackForce = 1f;

    public float moveSpeed = 1f;

    public float maxSpeed = 1f;

    public DetectionZone detectionZone;
    Rigidbody2D rb;

    DamageableCharacter damageableCharacter;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        damageableCharacter = GetComponent<DamageableCharacter>();
        //isNotDead = GetComponent<DamageableCharacter>().isLiving;
    }

    void FixedUpdate()
    {
        if(damageableCharacter.Targetable && detectionZone.detectedObjs.Count > 0)
        {
            Vector2 direction = (detectionZone.detectedObjs[0].transform.position - transform.position).normalized;
            rb.velocity = Vector2.ClampMagnitude(rb.velocity + (direction * moveSpeed * Time.deltaTime), maxSpeed);
        }
    }

    // public void Update()
    // {
    //     target.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    // }

    // public void DropItem()
    // {
    //     if(Random.Range(0f, 1f) <= m_dropChance)
    //     {
    //         Instantiate(collectable, target.position, transform.rotation);
    //         Debug.Log("Item Dropped");
    //     }
    //     Debug.Log("Item Not Dropped");
    // }

    void OnCollisionEnter2D(Collision2D col)
    {
        Collider2D collider = col.collider;
        IDamageable damageable = col.collider.GetComponent<IDamageable>();

        if(damageable != null)
        {
            Vector3 parentPosition = transform.position;

            Vector2 direction = (Vector2) (collider.gameObject.transform.position - transform.position).normalized;

            Vector2 knockback = direction * knockbackForce;

            damageable.OnHit(damage, knockback);
        }
    }
}
