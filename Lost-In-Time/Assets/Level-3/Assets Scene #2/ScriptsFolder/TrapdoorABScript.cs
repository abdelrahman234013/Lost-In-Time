using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapdoorABScript : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Animator trapdoorAnimator;  // Animator for the trapdoor
    public Collider2D trapdoorCollider;
    public AudioClip OpenSound;

     private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void DisableCollider()
    {
        if (trapdoorCollider != null)
        {
            trapdoorCollider.enabled = false;
        }
    }

    // Method to trigger the trapdoor opening animation
    public void OpenTrapdoor()
    {
        if (trapdoorAnimator != null)
        {
            trapdoorAnimator.SetTrigger("Opened");
            AudioManagerScript.instance.RandomizeSfx(OpenSound);
        }
        
    }
}
