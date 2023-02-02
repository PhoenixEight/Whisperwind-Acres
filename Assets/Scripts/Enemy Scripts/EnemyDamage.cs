using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] private float attackDamage = 10f;
    [SerializeField] private float attackSpeed = 0.5f;
    private float canAttack;

    public Collider2D coll;

    public bool playerInRange;

    private void OnTriggerStay2D(Collider2D collider)
    {

        if (collider.gameObject.tag == "Player")
        {
            playerInRange = true;
        }

        if (playerInRange == true)
        {
            if (attackSpeed <= canAttack)
            {
                collider.gameObject.GetComponent<PlayerHealth>().UpdateHealth(-attackDamage);
                canAttack = 0f;
            }
            else
            {
                canAttack += Time.deltaTime;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            collider.gameObject.GetComponent<PlayerHealth>().UpdateHealth(-attackDamage);
            canAttack = 0f;
        }

        if (collider.isTrigger)
        {
            Debug.Log("This Collider2D can be triggered");
        }
        else if (!collider.isTrigger)
        {
            Debug.Log("This Collider2D cannot be triggered");
        }

        if (collider.gameObject.tag == "Player")
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            playerInRange = false;
        }
    }
}
