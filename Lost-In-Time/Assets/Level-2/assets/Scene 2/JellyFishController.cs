using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyFishController : MonoBehaviour
{
    public Transform startPoint;  // Start point boundary
    public Transform middlePoint; // Middle point to determine water boundary
    public Transform endPoint;    // End point boundary
    public float speed = 2f;      // Speed of the jellyfish's movement
    public Animator animator;     // Reference to the Animator component
    public int damage = 1;

    private bool movingUp = true; // Direction of movement: true = up, false = down
    private float fixedX;         // Fixed x-coordinate of the jellyfish

    void Start()
    {
        // Store the fixed x-coordinate based on the initial position
        fixedX = transform.position.x;
    }

    void Update()
    {
        MoveJellyfish();  // Handle movement
        UpdateAnimation(); // Update animation based on position
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
        // Check if the jellyfish is outside the water (between middle and end point)
        bool isOutsideWater = transform.position.y >= middlePoint.position.y && transform.position.y <= endPoint.position.y;

        // Update animation based on the position
        if (isOutsideWater)
        {
            animator.SetBool("IsInWater", false); // Outside water
        }
        else
        {
            animator.SetBool("IsInWater", true); // Inside water
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the jellyfish collided with the Player
        if (collision.CompareTag("Player"))
        {
            // Stop moving up and immediately start moving down
            movingUp = false;
            HealthScript playerHealth = collision.gameObject.GetComponent<HealthScript>();
            if (playerHealth != null)
            {
            Debug.Log("Hit JellyFish");
            playerHealth.TakeDamage(damage);
        }
        }
    }
}


