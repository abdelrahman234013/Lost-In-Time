using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private int health = 3;                               // Player's starting health
    private int lives = 3;                                // Player's starting lives
    private float flickerTime = 0f;                       // Timer for sprite flickering
    public float flickerDuration = 0.1f;                  // Time for each flicker cycle
    private SpriteRenderer spriteRenderer;                // Reference to the player's SpriteRenderer component 
    public bool isImmune = false;                         // Flag indicating player's immunity status
    private float immunityTime = 0f;                      // Timer for immunity duration
    public float immunityDuration = 1.5f;                 // Length of immunity period
    public int coinsCollected = 0;


    void Start()
    {
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
    }

    public void CollectCoin(int coinValue)
    {

        this.coinsCollected = this.coinsCollected + coinValue;

    }

    void SpriteFlicker() // Method to create a flickering effect on the player's sprite during immunity
    {

        if (this.flickerTime < this.flickerDuration) // Check if the flicker timer hasn't reached the maximum duration yet
        {

            this.flickerTime = this.flickerTime + Time.deltaTime; // Update the flicker timer based on time passed since last frame
        }

        else if (this.flickerTime >= this.flickerDuration)        // Check if the flicker timer has reached or exceeded the duration
        {

            spriteRenderer.enabled = !(spriteRenderer.enabled);   // Make the player invisible 

            this.flickerTime = 0;                                 // Reset the flicker timer for the next cycle
        }
    }

    public void TakeDamage(int damage) // Public method to handle damage taken by the player    
    {

        if (this.isImmune == false) // Check if the player is not currently immune
        {
            this.health = this.health - damage; // Decrease the player's health by the damage amount

            if (this.health < 0) // Ensure health doesn't go below zero

                this.health = 0; // Set health to zero 

            if (this.lives > 0 && this.health == 0)  // Check if the player has lives remaining and health is zero
            {
                FindObjectOfType<LevelManager>().RespawnPlayer(); // Call the respawn method from the GameController script (Level Manager script in Lab)

                this.health = 6; // Reset player health

                this.lives--; // Decrease player lives by one
            }

            else if (this.lives == 0 && this.health == 0) // Check if the player has no lives and zero health (game over)
            {
                Debug.Log("Gameover"); // Debug message indicating game over

                Destroy(this.gameObject); // Destroy the player GameObject (game over)
            }
            Debug.Log("Player Health:" + this.health.ToString());
            // Debug messages showing current player health and lives								
            Debug.Log("Player Lives:" + this.lives.ToString());
        }
        PlayHitReaction();
    }
    void PlayHitReaction() // Method to trigger immunity and reset timers when the player takes damage

    {
        this.isImmune = true; // Set the player to immune

        this.immunityTime = 0f;  // Reset the immunity timer to zero
    }


    // Update is called once per frame
    void Update()
    {
        if (this.isImmune == true) // Check if the player is currently immune
        {
            SpriteFlicker(); // Call the SpriteFlicker method to create a flickering effect

            immunityTime = immunityTime + Time.deltaTime; // Update the immunity timer based on time passed since last frame

            if (immunityTime >= immunityDuration) // Check if immunity duration has ended
            {
                this.isImmune = false; // Disable immunity

                this.spriteRenderer.enabled = true; // Make the player's sprite visible again

                Debug.Log("Immunity has ended"); // Debug immunity ending message
            }
        }
    }





}
