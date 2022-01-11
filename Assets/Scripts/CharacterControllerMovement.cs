using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterControllerMovement : MonoBehaviour
{
    [SerializeField] private InputActionAsset playerControls;
    private InputAction movement;

    private CharacterController character;
    Vector3 movementVector;
    [SerializeField] private float speed = 10f;

    void Start()
    {
        var gameplayActionMap = playerControls.FindActionMap("XRI LeftHand");

        movement = gameplayActionMap.FindAction("Move");

        movement.performed += OnMovementChanged;
        movement.canceled += OnMovementChanged;
        movement.Enable();

        character = GetComponent<CharacterController>();
    }

    void FixedUpdate()
    {
        character.Move(movementVector * speed * Time.fixedDeltaTime);
    }

    public void OnMovementChanged(InputAction.CallbackContext context)
    {
        Vector2 direction = context.ReadValue<Vector2>();
        movementVector = new Vector3(direction.x, 0, direction.y);
    }
}