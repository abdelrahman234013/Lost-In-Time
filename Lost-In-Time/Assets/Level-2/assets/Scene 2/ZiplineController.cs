using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ZiplineController : MonoBehaviour
{
    public Transform startPoint; // Start of the zipline
    public Transform endPoint;   // End of the zipline
    public float speed = 5f;     // Fixed speed of zipline movement
    public Transform handle;     // Zipline handle
    public float hangOffset = 0.5f; // Distance between the handle and the player
    private bool isOnZipline = false; // Player is on the zipline
    private bool isPlayerNearby = false; // Player is near the zipline

    private Transform player;    // Reference to the player's transform
    private Vector3 ziplineDirection; // Direction vector of the zipline
    private Rigidbody2D playerRb; // Player's Rigidbody2D for physics-based control

    // Reference to the UI Image to show "E" when near the zipline
    public Image ziplineIndicator; 

    void Start()
    {
        // Calculate the normalized direction vector of the zipline
        ziplineDirection = (endPoint.position - startPoint.position).normalized;
        
        // Initially hide the zipline indicator
        if (ziplineIndicator != null)
        {
            ziplineIndicator.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        // Allow the player to start the zipline by pressing 'E' when nearby
        if (isPlayerNearby && !isOnZipline && Input.GetKeyDown(KeyCode.E))
        {
            StartZipline(player);
        }

        if (isOnZipline)
        {
            // Hide the "E" image while the player is on the zipline
            if (ziplineIndicator != null)
            {
                ziplineIndicator.gameObject.SetActive(false);
            }

            float horizontalInput = Input.GetAxis("Horizontal"); 
            float movementDirection = Mathf.Sign(horizontalInput); 

            Vector3 movement = ziplineDirection * movementDirection * speed * Time.deltaTime;
            Vector3 newPosition = player.position + movement;

            if (Vector3.Dot(newPosition - startPoint.position, ziplineDirection) >= 0 &&
                Vector3.Dot(newPosition - endPoint.position, ziplineDirection) <= 0)
            {
                // Update the player's position on the zipline
                player.position = newPosition;

                // Move the handle to follow the player's position
                if (handle != null)
                {
                    handle.position = new Vector3(player.position.x, player.position.y + hangOffset, player.position.z);
                }
            }
            else
            {
                // If the player reaches the end of the zipline, exit
                StopZipline();
            }
        }
    }

    public void StartZipline(Transform playerTransform)
    {
        player = playerTransform;
        playerRb = player.GetComponent<Rigidbody2D>();
        if (playerRb != null)
        {
            playerRb.velocity = Vector2.zero; // Stop any existing motion
            playerRb.isKinematic = true;     // Disable external forces
        }

        isOnZipline = true;

        // Snap the player to the zipline
        Vector3 closestPoint = Vector3.Project(player.position - startPoint.position, ziplineDirection) + startPoint.position;

        // Position the player below the handle
        player.position = new Vector3(closestPoint.x, closestPoint.y - hangOffset, player.position.z);

        // Snap the handle to the player's position
        if (handle != null)
        {
            handle.position = new Vector3(player.position.x, player.position.y + hangOffset, player.position.z);
        }
    }

    public void StopZipline()
    {
        isOnZipline = false;

        // Re-enable the player's Rigidbody2D to restore normal behavior
        if (playerRb != null)
        {
            playerRb.isKinematic = false;
            playerRb.velocity = Vector2.zero; // Stop motion upon exiting
        }

        // Show the "E" indicator again when the player leaves the zipline
        if (ziplineIndicator != null && isPlayerNearby)
        {
            ziplineIndicator.gameObject.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerNearby = true;
            player = collision.transform; // Cache the player's transform

            // Show the "E" indicator when the player is nearby
            if (!isOnZipline && ziplineIndicator != null)
            {
                ziplineIndicator.gameObject.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerNearby = false;

            // Hide the "E" indicator when the player leaves the area and is not on the zipline
            if (!isOnZipline && ziplineIndicator != null)
            {
                ziplineIndicator.gameObject.SetActive(false);
            }
        }
    }
}
