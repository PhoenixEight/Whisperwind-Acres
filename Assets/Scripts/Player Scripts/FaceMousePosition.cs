using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FaceMousePosition : MonoBehaviour
{
    public Vector2 PointerPosition {get; set; }

    private Vector2 pointerInput;

    private InputActionReference pointerPosition;

    void Update()
    {
        transform.right = (PointerPosition - (Vector2)transform.position).normalized;

        pointerInput = GetPointerInput();
        PointerPosition = pointerInput;
    }

    private Vector2 GetPointerInput()
    {
        Vector3 mousePos = pointerPosition.action.ReadValue<Vector2>();
        mousePos.z = Camera.main.nearClipPlane;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }
}
