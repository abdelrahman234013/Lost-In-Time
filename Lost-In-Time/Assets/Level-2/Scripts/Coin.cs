using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinValue = 1; // Value of the coin (can be customized)
    
    // This method is called when the player touches the coin (trigger area)
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Ensure it's the player that collides with the coin
        {
            // Increase the player's coin count
            CoinManger.instance.AddCoins(coinValue);
            
            // Destroy the coin object after being collected
            Destroy(gameObject);
        }
    }
}

