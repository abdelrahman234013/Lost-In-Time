using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaSwim : MonoBehaviour
{
    public float speed = 2f;             // Movement speed of the fish
    public bool movingRight = true;      // Direction of movement: true = right, false = left
    private Rigidbody2D rb;              // Reference to the Rigidbody2D

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        MoveFish();  // Move the fish horizontally
    }

    private void MoveFish()
    {
        // Move the fish horizontally
        float moveDirection = movingRight ? 1 : -1;
        
        // Keep the Y velocity the same (don't change the Y-axis)
        rb.velocity = new Vector2(moveDirection * speed, rb.velocity.y);
    }

    private void FlipDirection()
    {
        // Change direction
        movingRight = !movingRight;

        // Flip the fish's sprite
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    // Trigger event for when the fish collides with an object with the "Wall" tag
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the fish collided with an object tagged as "Ground"
        if (collision.CompareTag("Ground"))
        {
            FlipDirection();  // Flip the direction of the fish when it hits the wall
        }
        if (collision.CompareTag("Player")){
            if (FindObjectOfType<HealthScript>() != null){
            FindObjectOfType<HealthScript>().TakeDamage(1);
            FlipDirection();
            }
        }
    }
}
