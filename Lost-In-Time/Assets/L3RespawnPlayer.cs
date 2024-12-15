using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L3RespawnPlayer : MonoBehaviour
{

    private Vector3 respawnPosition;  // Store the last checkpoint position

    void Start()
    {
        respawnPosition = transform.position;  // Initialize to the starting position
    }

    // Method to set the player's respawn position to the last checkpoint
    public void SetCheckpoint(Vector3 newCheckpoint)
    {
        respawnPosition = newCheckpoint;
    }

    // Respawn the player at the last checkpoint
    public void RespawnAtCheckpoint()
    {
        transform.position = respawnPosition;
        // Optionally reset health, play idle animation, etc.
        HealthScript healthScript = GetComponent<HealthScript>();
        if (healthScript != null)
        {
            healthScript.Respawn();
        }

        Animator anim = GetComponent<Animator>();
        if (anim != null)
        {
            anim.Play("Idle");
        }
    }

    // For when the player dies completely (can be used for Game Over logic as well)
    public void OnPlayerDeath()
    {
        // Implement any death animations or game over handling here
    }
}
