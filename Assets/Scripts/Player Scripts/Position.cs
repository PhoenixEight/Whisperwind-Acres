using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Position : MonoBehaviour
{
    /*//Vector3 m_NewPosition;

    // Attach these in the Inspector window
    public InputField m_InputFieldY;

    // These are the strings that are returned from the InputFields
    string yString;

    // These are used when converting the strings to floats
    public static float m_YValue;

    /*void Start()
    {
        // Initialise the vector
        m_NewPosition = new Vector3(0.0f, 0.0f, 0.0f);
    } * /

    void Update()
    {
        // Store the inputs from the InputFields as strings
        yString = m_InputFieldY.text;

        // Convert the strings from the InputFields to floats
        ConvertStringsToFloats(yString);

        // Change the NewPosition Vector's x and y components
        //m_NewPosition.z = m_ZValue;

        // Change the position depending on the vector
        //transform.position = m_NewPosition;
        Debug.Log(m_YValue);
    }

    void ConvertStringsToFloats(string YVal)
    {
        try
        {
            // Convert the strings to floats
            m_YValue = float.Parse(YVal);
        }
        catch { }
    }*/
}