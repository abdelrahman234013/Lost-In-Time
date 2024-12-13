using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement; // For scene management (if you need to restart the game)

public class HealthScript : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;

    [Header("Lives")]
    [SerializeField] private int maxLives = 3; // Track the max lives
    private int remainingLives;

    [Header("iFrames")]
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer spriteRend;

    [Header("Components")]
    [SerializeField] private Behaviour[] components;

    [Header("Death Sound")]
    [SerializeField] private AudioClip deathSound;
    [SerializeField] private AudioClip hurtSound;

    private PlayerRespawn playerRespawn;

    // Reference to the GameManager (or Game script where the GameOver method is)
    private Game gameManager;

    private void Awake()
    {
        remainingLives = maxLives; // Initialize lives
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
        playerRespawn = GetComponent<PlayerRespawn>(); // Get the PlayerRespawn component
        gameManager = FindObjectOfType<Game>(); // Find the GameManager/Game script in the scene
    }

    public int health = 100;

    public void TakeDamage(int damage)
    {
        health -= damage;
 Debug.Log("Taking damage, current health: " + health);
        if (health <= 0 && !dead) // Only process death if not already dead
        {
            dead = true; // Mark the player as dead
            if (remainingLives > 1)
            {
                remainingLives--;
                Respawn(); // If player has lives left, respawn at checkpoint
            }
            else
            {
                Die(); // If last life is lost, player dies and shows game over panel
            }
        }
    }

    private void Die()
    {
        Debug.Log("Player Died");

        anim.SetTrigger("Dead"); // Trigger death animation

        // Play death sound, if any
        if (deathSound)
        {
            AudioSource.PlayClipAtPoint(deathSound, transform.position);
        }

        // Call the GameOver method in GameManager to show the restart panel
        if (gameManager != null)
        {
             Debug.Log("GameOver method called");
            gameManager.GameOver(); // Show the restart panel
            
        }
        else
        {
            Debug.LogError("GameManager not found!");
        }

        // Optionally, you can call respawn logic here if needed for other parts of the game
        // FindObjectOfType<ManagerScript>().RespawnPlayer(); // Respawn at last checkpoint
    }

    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }

    public void Respawn()
    {
        // If you respawn, reset health to full
        currentHealth = startingHealth;

        // Ensure player is no longer dead and reset animations
        anim.ResetTrigger("Dead");
        anim.Play("Idle"); // Play idle animation when respawned

        // Reset all components (e.g., movement, physics)
        foreach (Behaviour component in components)
        {
            component.enabled = true;
        }

        // Mark player as alive again
        dead = false;
    }
}
