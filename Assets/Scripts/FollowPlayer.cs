using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;

    // Update is called once per frame
    void Update()
    {
        //transform.position = player.transform.position + new Vector3(0, 1, 0);

        transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 1, 0);
    }
}