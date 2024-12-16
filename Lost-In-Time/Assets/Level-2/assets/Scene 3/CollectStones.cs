using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectStones : MonoBehaviour
{
    int collectedcoints = 0; 
    public AudioClip collectSound;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Check if the player collided with the stone
        {
            collectedcoints++; Destroy(gameObject);
            if (collectSound != null){
            AudioManagerScript.instance.PlaySingle(collectSound);
            }    
        }
    }
}
