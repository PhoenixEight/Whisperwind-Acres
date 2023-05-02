using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float damage = 1;

    const float m_dropChance = 1f / 6f;  // Set odds here (1/X)

    public GameObject collectable;

    public Transform target;

    public void Update()
    {
        target.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }



        // if(Random.Range(0f, 1f) <= m_dropChance )
        // {
        //     Instantiate(collectable, target.position, transform.rotation);
        //     //Debug.Log("Item Dropped");
        // }

    void OnCollisionEnter2D(Collision2D col)
    {
        IDamageable damageable = col.collider.GetComponent<IDamageable>();

        if(damageable != null)
        {
            damageable.OnHit(damage);
        }
    }
}
