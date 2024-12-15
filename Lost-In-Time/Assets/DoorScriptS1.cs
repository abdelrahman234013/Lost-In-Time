using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorUnlock : MonoBehaviour
{
    public int requiredKeys = 1; // Number of keys required to unlock the door
    public AudioClip doorUnlockSound; // Optional sound for unlocking the door

    private bool isUnlocked = false; // Prevents multiple unlocks





/*    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag("Player"))
        {
            // Access the player's stats to check key count
           // PlayerStatsIceS1 playerStats = other.GetComponent<PlayerStatsIceS1>();

            if (FindObjectOfType<PlayerStatsIceS1>() != null &&FindObjectOfType<PlayerStatsIceS1>().keyCollected = requiredKeys && !isUnlocked)
            {
                UnlockDoor();
            }
            else
            {
                Debug.Log("Door is locked. Collect more keys!");
            }
        }
    }

    void UnlockDoor()
    {
        isUnlocked = true;

        // Play door unlock sound if assigned
        if (doorUnlockSound != null)
        {
            AudioSource.PlayClipAtPoint(doorUnlockSound, transform.position);
        }

        // Destroy the door GameObject to make it disappear
        Destroy(gameObject);

        Debug.Log("Door Unlocked and removed!");
    } */

 void update(){
    if(FindObjectOfType<PlayerStatsIceS1>().keyCollected == true){
        Destroy(this.gameObject);
    }
 }

 void OnTriggerEnter2D(Collider2D other){
    if(FindObjectOfType<PlayerStatsIceS1>().keyCollected && other.tag == "Player"){
        Destroy(this.gameObject);
    }
 }

}