using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowEnemyBody : MonoBehaviour
/*{
    public Transform target;

    void Update()
    {
        transform.position = new Vector3(target.transform.position.x, target.transform.position.y, 0);
    }
}*/

{
    public Transform target;
    public float smoothTime = 0.3f;
    private Vector3 velocity = Vector3.zero;

    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, target.position, ref velocity, smoothTime);
    }

    /*void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target.transform.position, 100);
    }*/
}