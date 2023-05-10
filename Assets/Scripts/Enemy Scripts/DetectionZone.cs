using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionZone : MonoBehaviour
{
    public List<Collider2D> detectedObjs;
    Collider2D col;

    void Start()
    {
        col.GetComponent<Collider2D>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        detectedObjs.Add(collider);
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        detectedObjs.Remove(collider);
    }
}
