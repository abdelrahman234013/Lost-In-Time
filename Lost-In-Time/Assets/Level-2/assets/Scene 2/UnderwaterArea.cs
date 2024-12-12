using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderwaterArea : MonoBehaviour
{
    [SerializeField] private float damageInterval = 2f; // Damage every 2 seconds
    [SerializeField] private float initialDelay = 3f;   // Start damaging after 3 seconds
    [SerializeField] private int damageAmount = 1;  // Damage amount per interval

    private Coroutine damageCoroutine;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Start the damage coroutine when the player enters
            damageCoroutine = StartCoroutine(DamagePlayer(other.GetComponent<Health>()));
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Stop the damage coroutine when the player exits
            if (damageCoroutine != null)
            {
                StopCoroutine(damageCoroutine);
                damageCoroutine = null;
            }
        }
    }

    private IEnumerator DamagePlayer(Health playerHealth)
    {
        // Wait for the initial delay before starting damage
        yield return new WaitForSeconds(initialDelay);

        while (true)
        {
            // Apply damage to the player
            FindObjectOfType<PlayerStats>().TakeDamage(damageAmount);

            // Wait for the next damage interval
            yield return new WaitForSeconds(damageInterval);
        }
    }
}
