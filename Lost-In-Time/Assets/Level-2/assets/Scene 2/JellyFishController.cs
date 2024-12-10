using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyFishController : MonoBehaviour
{
    public Transform startPoint;  // Start point of the movement
    public Transform endPoint;    // End point of the movement
    public float speed = 2f;      // Speed of the jellyfish's movement
    public Animator animator;     // Reference to the Animator component

    private bool movingUp = true; // Direction of movement: true = up, false = down
    private float fixedX;         // Fixed x-coordinate of the jellyfish

    void Start()
    {
        // Ensure the jellyfish starts at the starting point
        transform.position = startPoint.position;
        // Store the fixed x-coordinate
        fixedX = startPoint.position.x;
    }

    void Update()
    {
        MoveJellyfish();  // Handle movement
        UpdateAnimation(); // Update animation based on y-position
    }

    private void MoveJellyfish()
    {
        // Determine the target y-coordinate based on the direction
        float targetY = movingUp ? endPoint.position.y : startPoint.position.y;

        // Move vertically towards the target y-coordinate while keeping the x-coordinate fixed
        transform.position = Vector3.MoveTowards(
            transform.position,
            new Vector3(fixedX, targetY, transform.position.z),
            speed * Time.deltaTime
        );

        // Check if the jellyfish has reached the target y-coordinate
        if (Mathf.Abs(transform.position.y - targetY) < 0.1f)
        {
            // Toggle direction
            movingUp = !movingUp;
        }
    }

    private void UpdateAnimation()
    {
        // Check if the jellyfish is above y = -5
        bool isAboveWaterLine = transform.position.y > -7;

        // Update animation based on the position
            if (isAboveWaterLine)
            {
                animator.SetBool("IsInWater", false);
            }
            else
            {
                animator.SetBool("IsInWater", true);
            }
    }

    private void OnTriggerEnter2D(Collider2D  collision)
    {
        // Check if the jellyfish collided with the Player
        if (collision.CompareTag("Player"))
        {
            // Stop moving up and immediately start moving down
            movingUp = false;
        }
    }
}
