using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private bool movingRight = true; // Determines the direction the rat is moving
    public float speed;
    [SerializeField] private float damage;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        anim.SetBool("isRunning", true);
    }

    private void Flip()
    {
        movingRight = !movingRight; // Toggle the direction
        Vector3 localScale = transform.localScale;
        localScale.x *= -1; // Flip the scale horizontally
        transform.localScale = localScale;
    }

    private void Update()
    {
        // Move the rat in the current direction
        float moveDirection = movingRight ? 1f : -1f;
        rb.velocity = new Vector2(moveDirection * speed, rb.velocity.y);
    }

    // Detect collision with the player and apply damage
private void OnCollisionEnter2D(Collision2D collision)
{
    if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("enemy"))
    {
        Flip();
    }

    if (collision.gameObject.CompareTag("Player"))
    {
        // Debug log to check if Health component is found
        Health playerHealth = collision.gameObject.GetComponent<Health>();
        if (playerHealth != null)
        {
            Debug.Log("Player Health component found!");
            playerHealth.TakeDamage(damage);
        }
        else
        {
            Debug.LogWarning("Health component not found on player!");
        }

        Flip();
    }
}

}