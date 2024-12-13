using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectStones : MonoBehaviour
{
    public bool isCollected = false; // Keeps track of whether the stone has been collected or not
    public AudioClip collectSound; // Reference to the sound clip for collecting
    private AudioSource audioSource;
    // When the player touches the stone, it gets collected.
    
    private void Start()
    {
        // Get the AudioSource component attached to the player or stone object
        audioSource = GetComponent<AudioSource>();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Check if the player collided with the stone
        {
            CollectStone(other.gameObject);
        }
    }

    // This method handles the stone collection
    // private void CollectStone(GameObject player)
    // {
    //     if (!isCollected)
    //     {
    //         isCollected = true;
    //         Notify the player that they have collected a stone
    //         player.GetComponent<CharcterScript>().CollectStone();
    //         Destroy(gameObject); // Destroy the stone object, but keep playing
    //     }
    // }
 private void CollectStone(GameObject player)
    {
        if (!isCollected)
        {
            isCollected = true;

            // Notify the player that they have collected a stone
            player.GetComponent<CharcterScript>().CollectStone();

            // Play the collection sound
            if (audioSource != null && collectSound != null)
            {
                audioSource.PlayOneShot(collectSound);
            }

            Destroy(gameObject); // Destroy the stone object, but keep playing
        }
    }


}

