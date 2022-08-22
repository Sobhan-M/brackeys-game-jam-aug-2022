using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpSpeed = 5f;

    private PlayerInputActions playerInputActions;
    private InputAction movement;
    private Rigidbody2D rb;
    private Collider2D playerCollider;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        rb = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
    }

    private void OnEnable()
    {
        movement = playerInputActions.Player.Movement;
        movement.Enable();

        playerInputActions.Player.Jump.performed += ctx => Jump();
        playerInputActions.Player.Jump.Enable();
    }

    private void OnDisable()
    {
        movement.Disable();
        rb.velocity = new Vector2(0, 0);

        playerInputActions.Player.Jump.Disable();
    }

    private void FixedUpdate()
    {
        float velocityX = movement.ReadValue<Vector2>().x * speed;
        float velocityY = rb.velocity.y;

        rb.velocity = new Vector2(velocityX, velocityY);
    }

    private void Jump()
    {
        if (playerCollider.IsTouchingLayers(LayerMask.GetMask("Floor")))
        {
            float jumpX = rb.velocity.x;
            float jumpY = jumpSpeed;

            rb.velocity = new Vector2(jumpX, jumpY);
        }
    }
}
