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
        // Health conditions and animation triggers
        if (health <= 0 && !isHurt) // Health reaches 0 and Hurt isn't active
        {
            Debug.Log("Health is 0 or below: Triggering Dead animation");
            StartCoroutine(TriggerDeadWithDelay());
        }
        else if (health < 50 && health > 0 && !isHurt) // Health below 50 but above 0
        {
            // Trigger hurt only if it hasn't been triggered already
            Debug.Log("Health is below 50: Triggering Hurt animation");
            StartCoroutine(TriggerHurtWithDelay());
        }
        else if (health > 50) // Health above 50, keep flying
        {
            birdAnimator.StartFlying();
        }

        // Debugging: Key press to test Hurt and Dead states
        if (Input.GetKeyDown(KeyCode.H)) // Press 'H' to test Hurt
        {
            Debug.Log("H key pressed: Triggering Hurt animation");
            birdAnimator.TakeDamage();
        }

        if (Input.GetKeyDown(KeyCode.D)) // Press 'D' to test Dead
        {
            Debug.Log("D key pressed: Triggering Dead animation");
            StartCoroutine(TriggerDeadWithDelay()); // Trigger Dead with a delay
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        // Trigger Hurt animation only when the health drops below a threshold
        if (health < 50 && !isHurt)
        {
            StartCoroutine(TriggerHurtWithDelay());
        }
    }

    public void Heal(int amount)
    {
        health += amount;
        if (health > 50)
        {
            birdAnimator.StartFlying(); // Go back to flying if health is above 50
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
