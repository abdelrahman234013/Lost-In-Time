using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxBoulderScript : MonoBehaviour
{
    public float moveSpeed = 3f;  // Speed of box movement
    private Rigidbody2D rb;
    /*public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;*/       // Rigidbody2D of the box

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  // Get the Rigidbody2D component of the box
    }

    // Method to move the box (either push or pull)
    public void MoveBox(Vector2 direction)
    {
        rb.velocity = direction * moveSpeed;
    }
}
