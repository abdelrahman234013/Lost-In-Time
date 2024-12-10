using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime;
    private GameObject player; // Reference to the player GameObject

    void Start()
    {
        // Find the player GameObject in the scene
        player = GameObject.FindWithTag("Player"); // Make sure your player GameObject has the "Player" tag

        if (player == null)
        {
            Debug.LogError("Player GameObject not found in the scene. Make sure it is tagged as 'Player'.");
        }
    }

    void Update()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }
        else if (remainingTime <= 0)
        {
            remainingTime = 0;

            // Destroy the player GameObject when the timer reaches 00:00
            if (player != null)
            {
                Destroy(player);
            }
        }

        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
