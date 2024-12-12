using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapdoorABScript : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Animator trapdoorAnimator;  // Animator for the trapdoor

     private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Method to trigger the trapdoor opening animation
    public void OpenTrapdoor()
    {
        if (trapdoorAnimator != null)
        {
            trapdoorAnimator.SetTrigger("Opened");
        }
        
    }
}
