using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControllerS1 : MonoBehaviour
{
   public bool isFacingRight = false;
    public float maxSpeed = 3f;
    public int damage = 6;
    public Sprite spriteRight; // Assign the right-facing sprite in the Inspector
    public Sprite spriteLeft;  // Assign the left-facing sprite in the Inspector

    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // Get the SpriteRenderer component
        UpdateSprite(); // Set the initial sprite
    }

    public void Flip()
    {
        isFacingRight = !isFacingRight; // Toggle the direction
        UpdateSprite(); // Update the sprite when flipping
        transform.localScale = new Vector3(
            -transform.localScale.x, 
            transform.localScale.y, 
            transform.localScale.z
        );
    }

    private void UpdateSprite()
    {
        // Update the sprite based on the current direction
        if (isFacingRight)
        {
            spriteRenderer.sprite = spriteRight;
        }
        else
        {
            spriteRenderer.sprite = spriteLeft;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<PlayerStatsIceS1>().TakeDamage(damage);
        }
    }
}
