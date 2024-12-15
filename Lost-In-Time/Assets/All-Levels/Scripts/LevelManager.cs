using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    
    public GameObject CurrentCheckPoint;

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

