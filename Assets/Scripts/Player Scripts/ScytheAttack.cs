using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScytheAttack : MonoBehaviour
{
    public Collider2D scytheCollider;
    public float damage = 3;
    Vector2 attackOffset;

    private void Start()
    {
        scytheCollider = GetComponent<Collider2D>();        attackOffset = transform.position;
    }

    public void AttackRight()
    {
        print("attack Right");
        scytheCollider.enabled = true;
        transform.localPosition = attackOffset;
    }

    public void AttackLeft()
    {
        print("attack left");
        scytheCollider.enabled = true;
        transform.localPosition = new Vector3(attackOffset.x * -1, attackOffset.y);
    }

    public void StopAttack()
    {
        scytheCollider.enabled = false;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            Enemy enemy = other.GetComponent<Enemy>();

            if(enemy != null)
            {
                enemy.Health -= damage;
            }
        }
    }
}
