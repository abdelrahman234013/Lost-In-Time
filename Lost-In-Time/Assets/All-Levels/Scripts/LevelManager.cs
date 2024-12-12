using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    // Ensure this field is defined to hold the current checkpoint
    public GameObject CurrentCheckPoint; // The current checkpoint object (use correct naming)

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void RespawnPlayer()
    {
        if (CurrentCheckPoint != null)
        {
            FindObjectOfType<CharacterMovements>().transform.position = CurrentCheckPoint.transform.position;
        }
        else
        {
            Debug.LogError("CurrentCheckPoint is not assigned in the LevelManager.");
        }
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
    }
}

