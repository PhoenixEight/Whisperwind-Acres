using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    public Collider2D col;

    [SerializeField]
    public FollowPlayer followPlayer;

    // public float offsetX = 0f;
    // public float offsetY = 0f;

    public bool ONLY_SELECT_ONE = true;
    public bool moveRight = true;
    public bool moveLeft = false;
    public bool moveUp = false;
    public bool moveDown = false;

    void Start()
    {
        //cameraMover = GameObject.FindGameObjectWithTag("CameraMover").GetComponent<CameraMover>();
        followPlayer = FindObjectOfType<FollowPlayer>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            if(moveRight == true)
            {
                followPlayer.MoveRight();

                Debug.Log("Camera Moved Right");
            }
            if(moveLeft == true)
            {
                followPlayer.MoveLeft();

                Debug.Log("Camera Moved Left");
            }
            if(moveUp == true)
            {
                followPlayer.MoveUp();

                Debug.Log("Camera Moved Up");
            }
            if(moveDown == true)
            {
                followPlayer.MoveDown();

                Debug.Log("Camera Moved Down");
            }

            //Debug.Log("Camera Moved");
        }
    }
}
