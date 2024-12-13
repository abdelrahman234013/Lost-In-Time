using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest3FishScript : MonoBehaviour
{
    public KeyCode openKey = KeyCode.E; // The key to open the chest
    public Animator chestanimator; // Assign the chest's Animator in the Inspector (optional)
    public GameObject fish; // Optional: Assign a reward prefab to instantiate when opened
    private bool isPlayerNearby = false; // Check if the player is near the chest
    private bool isOpen = false; // Check if the chest is already open
    public PlayerStatsIce player;
    public AudioClip OpenSound;

    void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(openKey) && !isOpen)
        {
            OpenChest();
        }
    }

    void OpenChest()
    {
        isOpen = true; // Mark the chest as opened

        // Trigger an animation if available
        if (chestanimator != null)
        {
            chestanimator.SetTrigger("Open"); 
            AudioManagerScript.instance.RandomizeSfx(OpenSound);
        }

        // Spawn a reward if specified
        if (fish != null)
        {
            Instantiate(fish, transform.position + Vector3.up, Quaternion.identity);
        
        }

        Debug.Log("Chest Opened, you recieved 3 fish! You now have " + player.fishCollected + " fish collected!");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true; // Player is near the chest
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false; // Player left the chest area
        }
    }
}
