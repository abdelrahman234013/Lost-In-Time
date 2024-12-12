using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Animator doorAnimator;  // Animator for the trapdoor

    public Button1Script button1;
    public Button2Script button2;
    public Button3Script button3;
    public Button4Script button4;

    /*private bool button1Pressed = false;
    private bool button2Pressed = false;
    private bool button3Pressed = false;
    private bool button4Pressed = false;*/

     private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    /*private void OnTriggerEnter(Collider other)
    {
            if (gameObject.name == "Button1")
            {
                button1Pressed = true;
                //button1Animator.SetTrigger("Pushed");
            }
            else if (gameObject.name == "Button2")
            {
                button2Pressed = true;
                //button2Animator.SetTrigger("Pushed");
            }
            else if (gameObject.name == "Button3")
            {
                button3Pressed = true;
                //button3Animator.SetTrigger("Pushed");
            }
            else if (gameObject.name == "Button4")
            {
                button4Pressed = true;
                //button4Animator.SetTrigger("Pushed");
            }

            CheckAllButtons();
        
    }*/

    public void CheckAllButtons()
    {
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
        }
        
    }
}
