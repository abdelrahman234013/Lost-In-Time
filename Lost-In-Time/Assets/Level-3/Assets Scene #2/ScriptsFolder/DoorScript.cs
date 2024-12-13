using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Animator doorAnimator;  // Animator for the trapdoor
    public Collider2D doorCollider;
    public AudioClip OpenSound;

    public Button1Script button1;
    public Button2Script button2;
    public Button3Script button3;
    public Button4Script button4;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void DisableCollider()
    {
        if (doorCollider != null)
        {
            doorCollider.enabled = false;
        }
    }

    public void CheckAllButtons()
    {
        Debug.Log($"Button 1: {button1.button1isPressed}, Button 2: {button2.button2isPressed}, Button 3: {button3.button3isPressed}, Button 4: {button4.button4isPressed}");
        
        if (button1.button1isPressed && button2.button2isPressed && button3.button3isPressed && button4.button4isPressed)
        {
            OpenDoor();
        }
    }

    // Method to trigger the trapdoor opening animation
    public void OpenDoor()
    {
        if (doorAnimator != null)
        {
            doorAnimator.SetTrigger("Opened");
            AudioManagerScript.instance.RandomizeSfx(OpenSound);
        }
    }
}
