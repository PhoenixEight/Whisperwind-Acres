using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FaceMousePosition : MonoBehaviour
{
    float raycast_depth = 100.0f;
    LayerMask floor_layer_mask;
    string floor_layer_name = "2D Floor";
    
    void Start()
    {
        floor_layer_mask = LayerMask.GetMask(floor_layer_name);
    }

    void Update()
    {
    //     LookAtMouse();
    // }

    // void LookAtMouse()
    // {
    	/** Face the mouse position while it's over the 2D game floor. **/

    	RaycastHit[] mouse_hits = GetMouseFloorHits();

        if(mouse_hits.Length == 1)
        {
            Vector3 hit_position = mouse_hits[0].point;
            LookAtPosition(hit_position);
        }
    }

    RaycastHit[] GetMouseFloorHits()
    {
    	/** Using the main camera and current mouse position, raycast through
    		a specific layer looking for the '2D Floor' game object. **/

    	Vector3 mouse_position = Mouse.current.position.ReadValue();
    	
        Ray mouse_ray = Camera.main.ScreenPointToRay(mouse_position);
        return Physics.RaycastAll(mouse_ray, raycast_depth, floor_layer_mask);
    }

    void LookAtPosition(Vector3 hit_position)
    {
    	/** Turn this game object to face a specific position. Flatten the 3D position to
    		local 2D space, to maintain parallel rotation with the game floor. **/

        Vector3 local_hit_position = transform.InverseTransformPoint(hit_position);
        local_hit_position.y = 0;
        Vector3 look_position = transform.TransformPoint(local_hit_position);

        // Using LookAt
        transform.LookAt(look_position, transform.up);

        // Using Quaternion
        //Vector3 look_direction = look_position - transform.position;
        //transform.rotation = Quaternion.LookRotation(look_direction, transform.up);
    }
}
