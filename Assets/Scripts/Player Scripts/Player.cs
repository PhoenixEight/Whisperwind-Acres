using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Inventory inventory;

    private void Awake(){
        inventory = new Inventory(21);
    }
}
