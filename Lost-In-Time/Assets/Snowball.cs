using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowball : MonoBehaviour
{
    public int damage = 5; // Amount of damage the snowball deals to the player

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Damage the player
            PlayerStatsIceS1 playerStats = other.GetComponent<PlayerStatsIceS1>();
            if (playerStats != null)
            {
                playerStats.TakeDamage(damage);
            }

            // Destroy the snowball
            Destroy(gameObject);
        }
        else if (other.CompareTag("Wall"))
        {
            // Destroy the snowball if it hits a wall
            Destroy(gameObject);
        }
    }
}
