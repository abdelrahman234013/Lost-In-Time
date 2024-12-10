using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdHealth : MonoBehaviour
{
    public BirdAnimationScript birdAnimator;
    public int health = 3;
    private float hurtDelay = 1f;  // Delay time for hurt animation (in seconds)
    private float deadDelay = 1f;  // Delay time for dead animation (in seconds)
    private bool isHurt = false;   // Flag to track if Hurt animation is in progress

    void Start()
    {
        // Ensure the bird starts flying when the game begins
        birdAnimator.StartFlying();
    }

    void Update()
{
    // If health is 0 or below, trigger the Dead animation
    if (health <= 0 && !isHurt)
    {
        Debug.Log("Health is 0 or below: Triggering Dead animation");
        StartCoroutine(TriggerDeadWithDelay());  // Call Dead with delay
    }
    // If health is below 50, but the bird isn't already hurt, then trigger Hurt animation
    // This condition will be checked only when actual damage is taken
    else if (health < 50 && !isHurt)  // Ensure hurt animation is triggered only if the bird is not already hurt
    {
        // We will no longer trigger Hurt animation here automatically
        // Just a debug log to track the health, you could keep or remove it
        Debug.Log("Health is below 50: Waiting for actual damage to trigger Hurt animation");
    }
    // If health is above 50, make sure the bird is flying
    else if (health > 50)
    {
        birdAnimator.StartFlying();
    }

    // Test Hurt animation with H key press
    if (Input.GetKeyDown(KeyCode.H)) // Press 'H' to manually trigger Hurt
    {
        Debug.Log("H key pressed: Triggering Hurt animation");
        birdAnimator.TakeDamage();  // Trigger the Hurt animation manually
    }

    // Test Dead animation with D key press
    if (Input.GetKeyDown(KeyCode.D)) // Press 'D' to manually trigger Dead animation
    {
        Debug.Log("D key pressed: Triggering Dead animation");
        birdAnimator.Die();
    }
}

public void TakeDamage(int damage)
{
    health -= damage;  // Decrease health by damage amount
    // Check if health is still above 0, and only trigger hurt animation if health < 50
    if (health > 0 && health < 50)
    {
        birdAnimator.TakeDamage();  // Trigger the Hurt animation
    }
    else if (health <= 0)
    {
        // Trigger dead animation if health is 0 or below
        birdAnimator.Die();
    }
}

public void Heal(int amount)
{
    health += amount;  // Increase health by heal amount
    if (health > 50)
    {
        birdAnimator.StartFlying();  // Start flying animation when health is above 50
    }
}


    // Coroutine to handle delay before the Hurt animation
    private IEnumerator TriggerHurtWithDelay()
    {
        isHurt = true;  // Set hurt flag to avoid duplicate triggers
        yield return new WaitForSeconds(hurtDelay); // Wait for the delay
        birdAnimator.TakeDamage();  // Trigger hurt animation
        isHurt = false; // Reset the hurt flag after the animation triggers
    }

    // Coroutine to handle delay before the Dead animation
    private IEnumerator TriggerDeadWithDelay()
    {
        yield return new WaitForSeconds(deadDelay); // Wait for delay
        birdAnimator.Die();  // Trigger dead animation
    }
}
