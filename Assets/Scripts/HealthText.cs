using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthText : MonoBehaviour
{
    public float timeToLive = 1f;
    public float floatSpeed = 500f;
    public Vector3 floatDirection = new Vector3(0, 1, 0);
    public TextMeshProUGUI textMesh;

    RectTransform rTransform;
    Color startingColor;

    float timeElapsed = 0.0f;

    void Start()
    {
        startingColor = textMesh.color;
        rTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        timeElapsed += Time.deltaTime;

        rTransform.position += floatDirection * floatSpeed * Time.deltaTime;

        textMesh.color = new Color(startingColor.r, startingColor.g, startingColor.b, 1 - (timeElapsed / timeToLive));

        if(timeElapsed > timeToLive)
        {
            Destroy(gameObject);
        }
    }
}
