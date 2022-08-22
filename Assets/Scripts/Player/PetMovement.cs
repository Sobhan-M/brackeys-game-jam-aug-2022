using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PetMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    private PlayerInputActions playerInputActions;
    private InputAction movement;
    private Rigidbody2D rb;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        movement = playerInputActions.Player.Movement;
        movement.Enable();
    }

    private void OnDisable()
    {
        movement.Disable();
        rb.velocity = new Vector2(0, 0);
    }

    private void FixedUpdate()
    {
        rb.velocity = speed * movement.ReadValue<Vector2>();
    }
}
