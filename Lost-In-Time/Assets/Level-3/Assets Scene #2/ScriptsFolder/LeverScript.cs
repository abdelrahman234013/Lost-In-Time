using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverScript : MonoBehaviour
{
    public AudioClip LeverSound;
    public PlatformScript platform; // Reference to the platform script
    public Animator leverAnimator; // Reference to the lever's Animator

    private string currentOption = "Option3"; // Starting option (middle)

    private void Update()
    {
        // Check for player input
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentOption = "Option1";
            platform.MovePlatformTo(currentOption);
            AnimateLever("Option3"); // Animate lever to option 3
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentOption = "Option2";
            platform.MovePlatformTo(currentOption);
            AnimateLever("Option2"); // Animate lever to option 2
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentOption = "Option3";
            platform.MovePlatformTo(currentOption);
            AnimateLever("Option1"); // Animate lever to option 1
        }
    }

    // Method to trigger the lever animation based on the selected option
    private void AnimateLever(string animationTrigger)
    {
        if (leverAnimator != null)
        {
            leverAnimator.SetTrigger(animationTrigger);
            AudioManagerScript.instance.RandomizeSfx(LeverSound);
        }
    }
}
