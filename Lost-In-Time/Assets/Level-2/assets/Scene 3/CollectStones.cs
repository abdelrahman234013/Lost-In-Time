using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectStones : MonoBehaviour
{
 
    public bool isCollected = false;

    // When the player touches the stone, it gets collected.
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Check if the player collided with the stone
        {
            CollectStone(other.gameObject);
        }
    }

    // This method handles the stone collection
    private void CollectStone(GameObject player)
    {
        if (!isCollected)
        {
            isCollected = true;
            // Notify the player that they have collected a stone
            player.GetComponent<CharcterScript>().CollectStone();
            Destroy(gameObject); // Destroy the stone
        }
    }
}
