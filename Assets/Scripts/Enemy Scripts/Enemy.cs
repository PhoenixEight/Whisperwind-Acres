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
    Animator animator;

    DamageableCharacter damageableCharacter;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        damageableCharacter = GetComponent<DamageableCharacter>();
        animator = GetComponent<Animator>();
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

        if(collider.gameObject.tag == "Player")
        {
            if(damageable != null)
            {
                Vector3 parentPosition = transform.position;

                Vector2 direction = (Vector2) (collider.gameObject.transform.position - transform.position).normalized;

                Vector2 knockback = direction * knockbackForce;

                damageable.OnHit(damage, knockback);
            }
        }
    }

    //Set this to the transform you want to check
    public Transform objectTransfom;
 
    private float noMovementThreshold = 0.0001f;
    private const int noMovementFrames = 3;
    Vector3[] previousLocations = new Vector3[noMovementFrames];
    private bool isMoving;
 
    //Let other scripts see if the object is moving
    public bool IsMoving
    {
        get{ return isMoving; }
    }
 
    void Awake()
    {
        //For good measure, set the previous locations
        for(int i = 0; i < previousLocations.Length; i++)
        {
            previousLocations[i] = Vector3.zero;
        }
    }
 
    void Update()
    {
        //Store the newest vector at the end of the list of vectors
        for(int i = 0; i < previousLocations.Length - 1; i++)
        {
            previousLocations[i] = previousLocations[i+1];
        }
        previousLocations[previousLocations.Length - 1] = objectTransfom.position;
 
        //Check the distances between the points in your previous locations
        //If for the past several updates, there are no movements smaller than the threshold,
        //you can most likely assume that the object is not moving
        for(int i = 0; i < previousLocations.Length - 1; i++)
        {
            if(Vector3.Distance(previousLocations[i], previousLocations[i + 1]) >= noMovementThreshold)
            {
                //The minimum movement has been detected between frames
                isMoving = true;
                animator.SetBool("isMoving", true);
                break;
        }
            else
            {
                animator.SetBool("isMoving", false);
                isMoving = false;
            }
        }
    }
}
