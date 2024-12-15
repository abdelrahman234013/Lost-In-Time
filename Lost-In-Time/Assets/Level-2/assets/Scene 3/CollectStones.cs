using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectStones : MonoBehaviour
{
    public bool isCollected = false; // Keeps track of whether the stone has been collected or not
    // When the player touches the stone, it gets collected.
    
    private void Start()
    {
        // Get the AudioSource component attached to the player or stone object
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Check if the player collided with the stone
        {
            CollectStone(other.gameObject);
        }
    }


 private void CollectStone(GameObject player)
    {
        if (!isCollected)
        {
            isCollected = true;

            player.GetComponent<CharcterScript>().CollectStone();
            Destroy(gameObject); 
        }
    }


}

