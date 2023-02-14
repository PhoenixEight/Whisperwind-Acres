using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private PlayerAnimations playerAnimations;

    private PlayerMover playerMover;
    
    [SerializeField]
    private InputActionReference movement, attack, pointerPosition;

    private Vector2 pointerInput, movementInput;

    private WeaponParent weaponParent;

    private void Awake()
    {
        playerAnimations = GetComponentInChildren<playerAnimations>();
        weaponParent = GetComponentInChildren<weaponParent>();
        playerMover = GetComponent<AgentMover>();
    }

    private void AnimateCharacter()
    {
        Vector2 lookDirection = pointerInput - (Vector2)transform.position;
        playerAnimations.RotateToPointer(lookDirection);
        playerAnimations.PlayAnimations(movementInput);
    }

    private void OnEnable()
    {
        attack.action.performed += PerformAttack;
    }

    private void OnDisable()
    {
        attack.action.performed -= PerformAttack;
    }

    private void PerformAttack(InputAction.CallbackContext obj)
    {
        if (weaponParent == null)
        {
            Debug.LogError("Weapon Parent is null", gameObject);
            return;
        }
        weaponParent.PerfromAnAttack();
    }

    private void Update()
    {
        pointerInput = GetPointerInput();
        weaponParent.PointerPosition = pointerInput;
        movementInput = movement.action.ReadValue<Vector2>().normalized;

        playerMover.MovementInput = movementInput;

        if (attack.action.inProgress)
        {

        }
    }

    private Vector2 GetPointerInput()
    {
        Vector3 mousePos = pointerPosition.action.ReadValue<Vector2>();
        mousePos.z = Camera.main.nearClipPlane;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }


}
