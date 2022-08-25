using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float speed = 3f;
    [SerializeField] Collider2D wallCollider;

    private Rigidbody2D rb;
    private float currentDirection;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        currentDirection = Mathf.Sign(Random.Range(-1, 1));
    }

    private void FixedUpdate()
    {
        Move(currentDirection);
        Turn();
        AdjustSpriteDirection();
    }

    private void Move(float direction)
    {
        Vector2 newVelocity = rb.velocity;
        newVelocity.x = speed * direction;
        rb.velocity = newVelocity;
    }

    private void Turn()
    {
        if (wallCollider.IsTouchingLayers(LayerMask.GetMask("Floor")) || wallCollider.IsTouchingLayers(LayerMask.GetMask("Ghost")))
        {
            currentDirection *= -1;
        }
    }

    private void AdjustSpriteDirection()
    {
        if (currentDirection < 0 && transform.localScale.x > 0)
        {
            Vector3 newScale = transform.localScale;
            newScale.x = Mathf.Abs(newScale.x) * -1;
            transform.localScale = newScale;
        }
        else if (currentDirection > 0 && transform.localScale.x < 0)
        {
            Vector3 newScale = transform.localScale;
            newScale.x = Mathf.Abs(newScale.x);
            transform.localScale = newScale;
        }
    }
}
