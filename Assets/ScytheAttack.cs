using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScytheAttack : MonoBehaviour
{
    Vector2 attackOffset;
    Collider2D scytheCollider;

    private void Start()
    {
        scytheCollider = GetComponent<Collider2D>();
        attackOffset = transform.position;
    }

    public void AttackRight()
    {
        print("attack Right");
        scytheCollider.enabled = true;
        transform.position = new Vector3(attackOffset.x + 1, attackOffset.y);
    }

    public void AttackLeft()
    {
        print("attack left");
        scytheCollider.enabled = true;
        transform.position = new Vector3(attackOffset.x - 1, attackOffset.y);
    }

    public void StopAttack()
    {
        scytheCollider.enabled = false;
    }
}
