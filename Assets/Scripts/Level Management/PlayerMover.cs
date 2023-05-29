using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    public Collider2D col;

    [SerializeField]
    public PlayerController playerController;

    public bool ONLY_SELECT_ONE = true;
    public bool moveRight = true;
    public bool moveLeft = false;
    public bool moveUp = false;
    public bool moveDown = false;

    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            if(moveRight == true)
            {
                playerController.MoveRight();

                Debug.Log("Camera Moved Right");
            }
            if(moveLeft == true)
            {
                playerController.MoveLeft();

                Debug.Log("Camera Moved Left");
            }
            if(moveUp == true)
            {
                playerController.MoveUp();

                Debug.Log("Camera Moved Up");
            }
            if(moveDown == true)
            {
                playerController.MoveDown();

                Debug.Log("Camera Moved Down");
            }

            //Debug.Log("Camera Moved");
        }
    }
}
