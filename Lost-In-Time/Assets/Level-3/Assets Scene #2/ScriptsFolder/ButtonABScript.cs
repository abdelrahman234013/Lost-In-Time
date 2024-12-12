using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonABScript : MonoBehaviour
{
    public bool isPressed = false;
    public Animator buttonanimator; // To track button state
    //public Color pressedColor = Color.red;
    //public Color defaultColor = Color.white;

    private SpriteRenderer spriteRenderer;
    public TrapdoorABScript trapdoor;

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
        }

        trapdoor.OpenTrapdoor();
            //spriteRenderer.color = pressedColor;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Box"))
        {
            isPressed = false;
            //spriteRenderer.color = defaultColor;
        }
    }
}
