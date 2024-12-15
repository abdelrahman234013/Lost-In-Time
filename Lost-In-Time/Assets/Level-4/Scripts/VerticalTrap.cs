using UnityEngine;

public class VerticalTrap : MonoBehaviour
{
    private Animator animator;  // Reference to the Animator component
    private float animationTime; // Store the current time of the animation

    private bool isActive = false; // Whether the trap is active (deals damage)
    public float workingTimeStart = 0.0f; // Time in the animation when it starts working
    public float workingTimeEnd = 0.5f; // Time in the animation when it stops working
    

    private void Start()
    {
        // Get the Animator component attached to this trap
        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("No Animator found on the trap.");
        }
    }

    private void Update()
    {
        // Get the current time in the animation
        animationTime = animator.GetCurrentAnimatorStateInfo(0).normalizedTime % 1f; // Loop normalized time

        // Check if the animation time is within the "working" period
        isActive = animationTime >= workingTimeStart && animationTime <= workingTimeEnd;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Only deal damage if the trap is active (working)
        if (isActive && collision.CompareTag("Player"))
        {
            // Call the TakeDamage method from PlayerStats
            PlayerStats playerStats = collision.GetComponent<PlayerStats>();
            if (playerStats != null)
            {
                playerStats.TakeDamage(3); // Deal damage to the player
            }
        }
    }
}
