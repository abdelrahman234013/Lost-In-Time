using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonABScript : MonoBehaviour
{
    public bool isPressed = false;
    public Animator buttonanimator; // To track button state
    private SpriteRenderer spriteRenderer;
    public TrapdoorABScript trapdoor;
    public AudioClip PushedSound;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Box"))
        {
            isPressed = true;

            if (buttonanimator != null)
        {
            buttonanimator.SetTrigger("Pushed");
            AudioManagerScript.instance.RandomizeSfx(PushedSound);
        }

        trapdoor.OpenTrapdoor();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Box"))
        {
            isPressed = false;
        }
    }
}
