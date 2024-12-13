using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneScript : MonoBehaviour
{
    private Rigidbody rb; // The Rigidbody of the stone
    public float damage = 10f; // Set the amount of damage the stone deals when it hits the player

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Get the Rigidbody component
    }

    // Freeze the stone's movement after hitting the ground
    private void FreezeStone()
    {
        rb.velocity = Vector3.zero;  // Stop the stone's movement
        rb.angularVelocity = Vector3.zero;  // Stop any rotational movement
        rb.isKinematic = true;  // Optionally, set to kinematic to stop all physics interaction
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the stone hits an object tagged as "Player"
        if (collision.CompareTag("Player"))
        {
            // Damage the player
            collision.GetComponent<Health>().TakeDamage(damage);
        }
        // Check if the stone hits an object tagged as "Ground"
        else if (collision.CompareTag("Ground"))
        {
            // Destroy the stone if it hits the ground
            Destroy(gameObject); // Destroys the stone object
        }
    }
}
