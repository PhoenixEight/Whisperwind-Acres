using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScytheHitbox : MonoBehaviour
{
    public float scytheDamage = 1f;
    public Collider2D scytheCollider;
    //public Vector2 attackOffset;
    public Vector3 faceRight = new Vector3(1, 0, 0);
    public Vector3 faceLeft = new Vector3(/*attackOffset.x*/1 * -1, 0, 0);
    
    void Start()
    {
        if(scytheCollider == null)
        {
            Debug.LogWarning("Sword Collider not set!");
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        col.SendMessage("OnHit", scytheDamage);
    }

    void IsFacingRight(bool isFacingRight)
    {
        if(isFacingRight)
        {
            gameObject.transform.localPosition = faceRight;
        }
        else
        {
            gameObject.transform.localPosition = faceLeft;
        }
    }
}//51:39