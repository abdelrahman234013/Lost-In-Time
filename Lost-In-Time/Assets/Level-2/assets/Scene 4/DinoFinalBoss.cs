using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoFinalBoss : MonoBehaviour
{
    public float speed = 2f;
    public bool movingRight = false;
    public float idleTime = 3f; // Time to stay idle before moving again
    public Transform startPoint; // Start point of the patrol
    public Transform endPoint;   // End point of the patrol

    private Animator animator;

    private bool isAttacking = false; // Check if the boss is in attack mode
    private bool isIdle = false;     // Flag to control idle state

    private float idleYPosition = -1.2f;   // Fixed y-position for idle state
    private float walkingYPosition = -1.4f; // Fixed y-position for walking state

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!isAttacking && !isIdle) // Only move if not attacking and not idle
        {
            MoveBoss();
        }
    }

    private void MoveBoss()
    {
        if (isAttacking || isIdle) return; // Don't move if attacking or idle

        float moveDirection = movingRight ? 1 : -1;
        Vector3 position = transform.position;
        position.x += moveDirection * speed * Time.deltaTime;
        position.y = walkingYPosition; // Set y-position for walking
        transform.position = position;

        // Check if the boss reached the start or end point
        if (movingRight && position.x >= endPoint.position.x)
        {
            ChangeDirection();
        }
        else if (!movingRight && position.x <= startPoint.position.x)
        {
            ChangeDirection();
        }
    }

    private void ChangeDirection()
    {
        movingRight = !movingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1; // Flip the sprite horizontally
        transform.localScale = localScale;

        StartCoroutine(IdleState()); // Enter idle state for 3 seconds
    }

    private IEnumerator IdleState()
    {
    isIdle = true; // Set idle flag to true
    animator.SetBool("IsIdle", true); // Enable idle animation
    animator.SetBool("IsWalking", false);
    animator.SetBool("Attack", false); // Ensure attacking animation is disabled

    Vector3 position = transform.position;
    position.y = idleYPosition; // Set y-position for idle state
    transform.position = position;

    // Initial idle phase
    yield return new WaitForSeconds(idleTime);

    // Play attack animation for 2 seconds
    animator.SetBool("IsIdle", false); // Disable idle animation
    animator.SetBool("IsWalking", false);
    animator.SetBool("Attack", true); // Enable attack animation
    yield return new WaitForSeconds(2f); // Wait for attack animation to finish

    // Post-attack idle phase
    animator.SetBool("Attack", false); // Disable attacking animation
    animator.SetBool("IsIdle", true); // Return to idle animation
    yield return new WaitForSeconds(idleTime);

    // After idle and attack animations, resume movement
    isIdle = false; // Reset idle flag
    animator.SetBool("IsIdle", false); // Disable idle animation
    animator.SetBool("IsWalking", true); // Enable walking animation
    }

    private IEnumerator AttackPlayer(Collider2D player)
    {
        isAttacking = true; // Set attacking state to true
        animator.SetTrigger("Attack"); // Trigger attack animation

        // Apply force to the player to knock them back
        Rigidbody2D playerRb = player.GetComponent<Rigidbody2D>();
        if (playerRb != null)
        {
            Vector2 knockbackForce = new Vector2(movingRight ? 5f : -10f, 10f);
            playerRb.velocity = Vector2.zero; // Stop the player momentarily before knockback
            playerRb.AddForce(knockbackForce, ForceMode2D.Impulse); // Knock the player back
        }

        // Wait for the attack animation to finish (adjust the wait time based on animation length)
        yield return new WaitForSeconds(1f); // Adjust this based on the animation length

        ChangeDirection(); // Flip direction after attack
        isAttacking = false; // End attacking state
        StartCoroutine(IdleState()); // Go to idle state for 3 seconds
    }
}