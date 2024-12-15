using System.Collections;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    [SerializeField] private AudioClip checkpoint;
    private Transform currentCheckpoint;
    private HealthScript playerHealth;

    private int lives = 1;  // Number of lives the player has

    private void Awake()
    {
        playerHealth = GetComponent<HealthScript>();
    }

    // This method will be called when the player dies
    public void OnPlayerDeath()
    {
        if (lives > 1)
        {
            lives--; // Deduct one life
            RespawnAtCheckpoint(); // Respawn the player at the last checkpoint
        }
        else if (lives == 1)
        {
            lives--; // Deduct the last life
            RespawnAtCheckpoint(); // Respawn the player at the last checkpoint
        }
        else
        {
            // Player has no lives left, handle game over here if necessary
            Debug.Log("Game Over");
        }
    }

    // Respawn the player at the last checkpoint
    public void RespawnAtCheckpoint()
    {
        if (flagscript.lastCheckpointPosition != Vector3.zero)
        {
            // Respawn the player at the last checkpoint's position
            transform.position = flagscript.lastCheckpointPosition;
            playerHealth.Respawn(); // Restore player health and reset animation
        }
        else
        {
            Debug.LogWarning("No checkpoint found!");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Checkpoint"))
        {
            currentCheckpoint = collision.transform;
            // Play sound if needed
            // SoundManager.instance.PlaySound(checkpoint);
            collision.GetComponent<Collider2D>().enabled = false;
            collision.GetComponent<Animator>().SetTrigger("activate");
        }
    }
}
