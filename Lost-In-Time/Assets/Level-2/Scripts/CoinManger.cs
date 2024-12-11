using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManger : MonoBehaviour
{
    public static CoinManger instance; // Singleton instance
    public Text coinCountText; // UI Text to display the coin count

    private int coinCount = 0; // Current coin count

    void Awake()
    {
        // Ensure only one instance of CoinManager exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Keep this object alive across scenes
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate CoinManager
        }
    }

    // Method to add coins to the coin count
    public void AddCoins(int amount)
    {
        coinCount += amount;
        UpdateCoinCountDisplay(); // Update the UI display whenever coins are added
    }

    // Method to update the UI text
    private void UpdateCoinCountDisplay()
    {
        if (coinCountText != null)
        {
            coinCountText.text = "Coins: " + coinCount.ToString();
        }
    }
}
