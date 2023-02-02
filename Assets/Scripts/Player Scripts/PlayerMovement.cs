using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D body;

    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;
    //public float zLevel;

    Animator animator;

    public float runSpeed = 20.0f;

    //[SerializeField] private float updateSpeed = 1f;
    //private float canUpdate;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();

        animator = GetComponent<Animator>();
        animator.SetBool("isWalking", false);
        animator.SetFloat("animHorizontal", 1);
    }


    void Update()
    {
        // Gives a value between -1 and 1
        horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
        vertical = Input.GetAxisRaw("Vertical"); // -1 is down
        
        if (horizontal == 0 && vertical == 0)
        {
            animator.SetBool("isWalking", false);
        }
        else
        {
            animator.SetBool("isWalking", true);
            animator.SetFloat("animHorizontal", horizontal);
        }

        //zLevel = transform.position.y;

        //update the position
        //transform.position = new Vector3(transform.position.x, transform.position.y, zLevel);

        /*if (updateSpeed <= canUpdate)
        {
            //output to log the position change
            Debug.Log(transform.position.z);
            canUpdate = 0f;
        }
        else
        {
            canUpdate += Time.deltaTime;
        }*/

        
    }


    void FixedUpdate()
    {
        if (horizontal !=0 && vertical !=0) //Check for diagonal movement
        {
            // Limit movement speed diagonally, so you move at 70% speed
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }

        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }
}
