using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 150f;
    public float maxSpeed = 8f;
    public float idleFriction = 0.9f;
    public float moveMultiplier = 1f;

    public ContactFilter2D movementFilter;
    public ScytheAttack scytheAttack;

    Rigidbody2D rb;
    Animator animator;
    SpriteRenderer spriteRenderer;
    Vector2 moveInput = Vector2.zero;
    
    bool isMoving = false;
    bool canMove = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        if(canMove == true && moveInput != Vector2.zero)
        {
            rb.velocity = Vector2.ClampMagnitude(rb.velocity + (moveInput * moveSpeed * Time.deltaTime * moveMultiplier), maxSpeed * moveMultiplier);

            if(moveInput.x > 0)
            {
                spriteRenderer.flipX = false;
            } 
            else if(moveInput.x < 0)
            {
                spriteRenderer.flipX = true;
            }

            isMoving = true;
        }
        else
        {
            //rb.velocity = Vector2.Lerp(rb.velocity, Vector2.zero, idleFriction);

            isMoving = false;
        }

        UpdateAnimatorParameters();
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void OnSprint()
    {
        moveMultiplier = 3;
    }

    void OnSprintStop()
    {
        moveMultiplier = 1;
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

    public void ScytheAttack()
    {
        LockMovement();
        if(spriteRenderer.flipX == true)
        {
            scytheAttack.AttackLeft();
        } 
        else 
        {
            scytheAttack.AttackRight();
        }
    }

    public void EndScytheAttack()
    {
        UnlockMovement();
        scytheAttack.StopAttack();
    }

    public void LockMovement()
    {
        canMove = false;
    }

    public void UnlockMovement()
    {
        canMove = true;
    }
}
