using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScytheHitbox : MonoBehaviour
{
    public float scytheDamage = 1f;
    public Collider2D scytheCollider;
    
    void Start()
    {
        if(scytheCollider == null)
        {
            Debug.LogWarning("Sword Collider not set!");
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        col.collider.SendMessage("OnHit", scytheDamage);
    }
}
