using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdAnimationScript : MonoBehaviour
{
    private Animator animator;
    public enum BirdState { Fly, Dead, Hurt }
    private BirdState currentState;

    public bool isFlying = false;
    public bool isDead = false;
    public bool isHurt = false;

    void Start()
    {
        // Get the Animator component attached to the bird
        animator = GetComponent<Animator>();

        // Start in the 'Fly' state by default
        SetState(BirdState.Fly);
    }

    void Update()
    {
        // Update the state based on the flags (this can be triggered from other scripts too)
        if (isDead)
        {
            SetState(BirdState.Dead);
        }
        else if (isHurt)
        {
            SetState(BirdState.Hurt);
        }
        else if (isFlying)
        {
            SetState(BirdState.Fly);
        }
    }

    // Method to set the state and trigger the appropriate animation transitions
    private void SetState(BirdState newState)
    {
        if (currentState == newState)
            return; // No need to change if already in this state

        // Update the current state
        currentState = newState;

        // Reset all animation booleans before setting the new state
        animator.SetBool("isFlying", false);
        animator.SetBool("isDead", false);
        animator.SetBool("isHurt", false);

        // Set the correct animation state based on the bird's current status
        switch (newState)
        {
            case BirdState.Fly:
                animator.SetBool("isFlying", true);
                break;
            case BirdState.Dead:
                animator.SetBool("isDead", true);
                break;
            case BirdState.Hurt:
                animator.SetBool("isHurt", true);
                break;
        }
    }

    // Method to trigger the Hurt animation
    public void TakeDamage()
    {
        isHurt = true;
        isFlying = false;
        isDead = false;
        SetState(BirdState.Hurt);
    }

    // Method to trigger the Dead animation
    public void Die()
    {
        isDead = true;
        isFlying = false;
        isHurt = false;
        SetState(BirdState.Dead);
    }

    // Method to trigger the Flying animation
    public void StartFlying()
    {
        isFlying = true;
        isHurt = false;
        isDead = false;
        SetState(BirdState.Fly);
    }

    // Optionally, call this to reset back to flying after hurt or dead states
    public void ResetToFlying()
    {
        isFlying = true;
        isDead = false;
        isHurt = false;
        SetState(BirdState.Fly);
    }
}
