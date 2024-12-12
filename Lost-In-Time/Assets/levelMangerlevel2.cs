using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelMangerlevel2 : MonoBehaviour
{
    public GameObject player;

    // Respawn the player at the last checkpoint position
    public void RespawnPlayer()
    {
        // Check if a checkpoint exists and the position is set
        if (flagscript.lastCheckpointPosition != Vector3.zero)  // Check if it's not default (zero)
        {
            player.transform.position = flagscript.lastCheckpointPosition;
        }
    }
}
