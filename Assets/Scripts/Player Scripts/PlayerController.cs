using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float collisionOffset = 0.05f;
    public ContactFilter2D movementFilter;
    
    Vector2 movementInput;
    Rigidbody2D rb;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        //if movement is not 0, try to move
        if(movementInput != Vector2.zero)
        {
            Debug.Log("Trying to move");
            bool success = TryMove(movementInput);

            if(!success)
            {
                success = TryMove(new Vector2(movementInput.x, 0));
                Debug.Log("Moving Horizontally");

                if(!success)
                {
                    success = TryMove(new Vector2(0, movementInput.y));
                    Debug.Log("Moving Vertically");
                }
            }
        }
    }

    private bool TryMove(Vector2 direction)
    {
        int count = rb.Cast(movementInput, movementFilter, castCollisions, moveSpeed * Time.fixedDeltaTime + collisionOffset);

            if(count==0)
            {
                rb.MovePosition(rb.position + movementInput * moveSpeed * Time.fixedDeltaTime);
                Debug.Log("Returned True");
                return true;
            }
            else
            {
                Debug.Log("Returned False");
                return false;
            }

        void OnMove(InputValue movementValue)
        {
            movementInput = movementValue.Get<Vector2>();
        }
    }
}
