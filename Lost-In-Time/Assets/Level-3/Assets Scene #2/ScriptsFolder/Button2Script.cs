using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button2Script : MonoBehaviour
{
    public bool button2isPressed = false;
    public Animator buttonanimator; // To track button state

    private SpriteRenderer spriteRenderer;
    public DoorScript door;
    public AudioClip PushedSound;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Box"))
        {
            button2isPressed = true;

            if (buttonanimator != null)
        {
            buttonanimator.SetTrigger("Pushed");
            AudioManagerScript.instance.RandomizeSfx(PushedSound);
        }

         Invoke(nameof(DelayedCheckAllButtons), 0.1f);

        }
    }

    private void DelayedCheckAllButtons()
    {
        door.CheckAllButtons();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Box"))
        {
            button2isPressed = false;
        }
    }
}
