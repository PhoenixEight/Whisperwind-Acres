using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    public float Health { get; set; }
    public bool Targetable { get; set; }

    public float _health = 3f;
    public bool _targetable = true;

    public void OnHit(float damage, Vector2 knockback)
    {

    }

    public void OnHit(float damage)
    {

    }

    public void OnObjectDestroyed()
    {

    }

}
