using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;

    public float multiplier = 0.1f;

    private float offsetX = 0f;
    private float offsetY = 0f;

    public float offsetXChange = 0f;
    public float offsetYChange = 0f;

    void FixedUpdate()
    {
        transform.position = new Vector3(offsetX + player.transform.position.x * multiplier, offsetY + player.transform.position.y * multiplier + 1, 0);
    }


    public void MoveRight()
    {
        offsetX = offsetX + offsetXChange;
    }

    public void MoveLeft()
    {
        offsetX = offsetX - offsetXChange;
    }

    public void MoveUp()
    {
        offsetY = offsetY + offsetYChange;
    }

    public void MoveDown()
    {
        offsetY = offsetY - offsetYChange;
    }
}