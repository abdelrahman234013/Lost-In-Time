using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CheckPoints : MonoBehaviour
{
   // Start is called before the first frame update
      void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Set the checkpoint position to the player's position
            //FindObjectOfType<L3RespawnPlayer>().SetCheckpoint(transform.position);
        }
    }
}

