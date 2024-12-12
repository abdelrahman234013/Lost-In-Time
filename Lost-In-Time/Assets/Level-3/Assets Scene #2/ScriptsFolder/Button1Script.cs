using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button1Script : MonoBehaviour
{
    public bool button1isPressed = false;
    public Animator buttonanimator; // To track button state
    //public Color pressedColor = Color.red;
    //public Color defaultColor = Color.white;

    private SpriteRenderer spriteRenderer;
    public DoorScript door;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Box"))
        {
            button1isPressed = true;

            if (buttonanimator != null)
        {
            buttonanimator.SetTrigger("Pushed");
        }

        door.CheckAllButtons();

        //door.Door();
            //spriteRenderer.color = pressedColor;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Box"))
        {
            button1isPressed = false;
            //spriteRenderer.color = defaultColor;
        }
    }
}
