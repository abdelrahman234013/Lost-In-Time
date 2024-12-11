using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPadScene3 : MonoBehaviour
{
    public float jumpForce = 10f;

    // Triggered when something enters the trigger zone
    private void OnTriggerEnter2D(Collider2D collider)
    {
        // Check if the colliding object has the "Player" tag
        if (collider.gameObject.CompareTag("Player"))
        {
            collider.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}
