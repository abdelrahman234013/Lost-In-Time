using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerStats : MonoBehaviour
{
<<<<<<< Updated upstream
    public int health = 3; // Health for the current heart (this is per heart)
    public int maxHealth = 3; // Maximum health per heart
    public int lives = 3; // Total number of hearts (lives)
    private int maxLives = 3; // Number of hearts the player can have

=======
    public int health = 3;
    public int lives = 3;
>>>>>>> Stashed changes
    public float flickerTime = 0f;
    public float flickerDuration = 0.1f;
    private SpriteRenderer spriteRenderer;
    public bool isImmune = false;
    public float immuneTime = 0f;
    public float immuneDuration = 1.5f;
    public bool hasCard = false;
    public bool hasCapsule = false;
    private int coinsCollected = 0;
    private Animator animator;

    public TextMeshProUGUI ScoreUI;  // Score UI to show collected coins
    public Image healthbar; // Health bar Image reference
    public Image[] heartImages; // Array of heart images for lives (drag all heart images in the inspector)

    void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();

        // Initialize heart images based on the current lives
        UpdateHearts();
    }

    void Update()
    {
        if (this.isImmune == true)
        {
            SpirteFlicker();
            immuneTime += Time.deltaTime;
            if (immuneTime >= this.immuneDuration)
            {
                this.isImmune = false;
                this.spriteRenderer.enabled = true;
            }
        }

        ScoreUI.text = "" + coinsCollected;
    }

    void SpirteFlicker()
    {
        if (animator != null && !this.isImmune)
        {
            if (this.flickerTime < this.flickerDuration)
            {
                this.flickerTime += Time.deltaTime;
            }
            else
            {
                spriteRenderer.enabled = !spriteRenderer.enabled;
                this.flickerTime = 0f;
            }
        }
    }

    public void TakeDamage(int damage)
    {
        if (!this.isImmune && health > 0)
        {
            this.health -= damage;
            if (this.health < 0) this.health = 0;

            // Update health bar based on current health
            healthbar.fillAmount = (float)health / maxHealth;  // Divide by maxHealth to dynamically adjust health bar

            // Check if health in current heart is 0
            if (this.health == 0 && this.lives > 0)
            {
                // Decrease the life (heart) and reset health for the next heart
                this.lives--;
                health = maxHealth;  // Reset health for the next heart

                // Update hearts display
                UpdateHearts();

                // Respawn if there are remaining lives
                if (this.lives > 0)
                {
                    FindObjectOfType<LevelManager>().RespawnPlayer();
                }
            }
            else if (this.lives == 0 && this.health == 0)
            {
                TriggerDeathAnimation();
            }

            Debug.Log("Player Health: " + this.health.ToString());
        }

        PlayHitReaction();
    }

    void TriggerDeathAnimation()
    {
        if (animator != null)
        {
            animator.SetTrigger("Death");
        }
        StartCoroutine(HandleDeath());
    }

    IEnumerator HandleDeath()
    {
        yield return new WaitForSeconds(2f);
        FindObjectOfType<LevelManager>().GameOver();
        Destroy(this.gameObject);
    }

    void PlayHitReaction()
    {
        this.isImmune = true;
        this.immuneTime = 0f;

        if (animator != null)
        {
            animator.ResetTrigger("Hurt");
            animator.SetTrigger("Hurt");
        }
    }

    public void CollectCoin(int coinValue)
    {
        this.coinsCollected += coinValue;
    }

    // Update hearts display based on the current lives
    private void UpdateHearts()
    {
        for (int i = 0; i < maxLives; i++)
        {
            // If the player has more than i lives, set the heart to active
            if (i < lives)
            {
                heartImages[i].enabled = true;  // Show heart
            }
            else
            {
                heartImages[i].enabled = false; // Hide heart
            }
        }
    }
}
