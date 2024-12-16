using System.Collections;
using System.Collections.Generic;
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
    public int remainingLives;

    [Header("iFrames")]
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer spriteRend;

    [Header("Components")]
    [SerializeField] private Behaviour[] components;

    [Header("Audio")]
    [SerializeField] private AudioClip deathSound;
    [SerializeField] private AudioClip hurtSound;

    public Transform CurrentCheckpoint;
    private PlayerRespawn playerRespawn;
    public GameObject RestartButton;

    // Reference to the GameManager (or Game script where the GameOver method is)
    private Game gameManager;

    private void Awake()
    {
        remainingLives = maxLives; // Initialize lives
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
        gameManager = FindObjectOfType<Game>(); // Find the GameManager/Game script in the scene
        if (RestartButton != null){
            RestartButton.SetActive(false);
        }
    }

    private void Update(){
    }

    public void TakeDamage(float damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            anim.SetTrigger("Hurt");
            // Add iframe logic if needed
        }
        else if (!dead)
        {
            dead = true;
            if (remainingLives > 1)
            {
                remainingLives--;
                Respawn(); // If player has lives left, respawn at checkpoint
            }
            else
            {
                SceneManager.LoadScene("GameOver");
                //RestartButton.SetActive(true);
                //Die(); // If last life is lost, player dies and shows game over panel
            }
        }
    }

    private void Die()
    {
        remainingLives = 0;
        anim.SetTrigger("Death"); // Trigger death animation

        // Play death sound, if any
        if (deathSound)
        {
            AudioSource.PlayClipAtPoint(deathSound, transform.position);
        }

        // Show Game Over panel
        if (gameManager != null)
        {
            gameManager.GameOver(); // Show the restart panel
        }

        // Optionally, activate buttons or other UI
    }

    public void AddHealth(float value)
    {
        currentHealth = Mathf.Clamp(currentHealth + value, 0, startingHealth);
    }

    public void Respawn()
    {
        transform.position = CurrentCheckpoint.position;

        // Reset health to full
        currentHealth = startingHealth;

        // Reset animations
        anim.ResetTrigger("death");
        anim.Play("Idle"); // Play idle animation when respawned

        // Re-enable components (e.g., movement, physics)
        foreach (Behaviour component in components)
        {
            component.enabled = true;
        }

        // Mark player as alive again
        dead = false;
    }

}