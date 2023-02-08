using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public float smoothing = 5f;

    private Vector3 offset;

    public float multiplier = 0.1f;

    void Start()
    {
        offset = transform.position - player.position;
    }

    void FixedUpdate()
    {
        transform.position = new Vector3(player.transform.position.x * multiplier, player.transform.position.y * multiplier + 1, 0);
    }

    /*void FixedUpdate()
    {
        Vector3 targetCamPos = player.position + offset;
        transform.position.x = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
    }*/
}