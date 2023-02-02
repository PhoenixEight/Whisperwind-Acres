using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZLevel : MonoBehaviour
{
    public float zLevel;

    // Update is called once per frame
    void Update()
    {
        zLevel = transform.position.y;

        transform.position = new Vector3(transform.position.x, transform.position.y, zLevel + 27);
    }
}
