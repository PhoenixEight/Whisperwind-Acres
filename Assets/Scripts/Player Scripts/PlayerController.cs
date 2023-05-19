using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour, IDataPersistence
{
    public float moveSpeed = 150f;
    public float maxSpeed = 8f;
    public float idleFriction = 0.9f;
    public float moveMultiplier = 1f;

    public ContactFilter2D movementFilter;
    //public ScytheAttack scytheAttack;

    //public GameObject scytheHitbox;
    Rigidbody2D rb;
    Animator animator;
    SpriteRenderer spriteRenderer;

    Collider2D scytheCollider;
    Vector2 moveInput = Vector2.zero;
    
    bool isMoving = false;
    bool isWalking = false;
    bool isSprinting = false;
    bool canMove = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        //scytheCollider = scytheHitbox.GetComponent<Collider2D>();
    }

    void FixedUpdate()
    {
        if(canMove == true && moveInput != Vector2.zero)
        {
            rb.velocity = Vector2.ClampMagnitude(rb.velocity + (moveInput * moveSpeed * Time.deltaTime * moveMultiplier), maxSpeed * moveMultiplier);
            //rb.AddForce(moveInput * moveSpeed * moveMultiplier * Time.deltaTime);

            if(moveInput.x > 0)
            {
                spriteRenderer.flipX = false;
                gameObject.BroadcastMessage("IsFacingRight", true);
            } 
            else if(moveInput.x < 0)
            {
                spriteRenderer.flipX = true;
                gameObject.BroadcastMessage("IsFacingRight", false);
            }

            if(isSprinting == true)
            {
                isWalking = false;
                animator.SetBool("isWalking", false);
            }
            else isWalking = true;
            animator.SetBool("isWalking", true);

            isMoving = true;
            animator.SetBool("isMoving", true);
        }
        else
        {
            //rb.velocity = Vector2.Lerp(rb.velocity, Vector2.zero, idleFriction);

            isWalking = false;
            animator.SetBool("isWalking", false);

            isMoving = false;
            animator.SetBool("isMoving", false);
        }

        UpdateAnimatorParameters();
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void OnSprint()
    {
        if(isMoving == true)
        {
            isSprinting = true;
            animator.SetBool("isSprinting", true);
        }

        moveMultiplier = 3;
    }

    void OnSprintStop()
    {
        isSprinting = false;
        moveMultiplier = 1;
        animator.SetBool("isSprinting", false);
    }

    void UpdateAnimatorParameters()
    {
        animator.SetFloat("moveX", moveInput.x);
        animator.SetFloat("moveY", moveInput.y);
    }

    void OnFire()
    {
        animator.SetTrigger("scytheAttack");
    }

    // public void ScytheAttack()
    // {
    //     LockMovement();
    //     if(spriteRenderer.flipX == true)
    //     {
    //         scytheAttack.AttackLeft();
    //     } 
    //     else 
    //     {
    //         scytheAttack.AttackRight();
    //     }
    // }

    // public void EndScytheAttack()
    // {
    //     UnlockMovement();
    //     scytheAttack.StopAttack();
    // }

    public void LockMovement()
    {
        canMove = false;
    }

    public void UnlockMovement()
    {
        canMove = true;
    }

    //Conner save/load system stuff for saving player position!!:
    
    public void LoadData(GameData data)
    {
        this.transform.position = data.playerPosition;
    }

    public void SaveData(ref GameData data)
    {
        data.playerPosition = this.transform.position;
    }
}
