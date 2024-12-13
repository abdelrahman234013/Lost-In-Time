using System.Collections;
using UnityEngine;


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

    private void Awake()
    {
        remainingLives = maxLives; // Initialize lives
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
        playerRespawn = GetComponent<PlayerRespawn>(); // Get the PlayerRespawn component
    }

    public int health = 100;

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            // Handle death (e.g., call death logic)
            if (remainingLives > 1)
            {
                remainingLives--;
                Respawn(); // If player has lives left, respawn at checkpoint
            }
            else
            {
                Die(); // If last life is lost, player dies and respawns at checkpoint
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

        // Call respawn logic from the Level Manager to respawn at the checkpoint
        FindObjectOfType<ManagerScript>().RespawnPlayer(); // Respawn at last checkpoint
    }

    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }

    public void Respawn()
    {
        currentHealth = startingHealth; // Reset health
        anim.ResetTrigger("Dead");
        anim.Play("Idle"); // Play idle animation when respawned

        // Reset all components (e.g., movement, physics)
        foreach (Behaviour component in components)
            component.enabled = true;
    }
}

