using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerScript : MonoBehaviour
{
       public GameObject CurrentCheckpoint; // Current checkpoint the player is at

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RespawnPlayer()
    {
        // Move player to the checkpoint position
        FindObjectOfType<CharcterScript>().transform.position = CurrentCheckpoint.transform.position;

        // Reset health and start idle animation
        HealthScript healthScript = FindObjectOfType<HealthScript>();
        if (healthScript != null)
        {
            healthScript.Respawn();
        }
    }
}
