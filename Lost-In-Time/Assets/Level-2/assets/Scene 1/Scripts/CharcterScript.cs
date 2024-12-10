using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // Import this if you are using UI elements

public class CharcterScript : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D body;
    private Animator anim;
    private bool grounded;

    // Stone collection variables
    public int stonesCollected = 0; // The number of collected stones
    public Text stonesText; // Reference to a UI Text to display the stone count

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        // Ensure that the stone text UI is updated on start
        UpdateStoneCountUI();
    }

    // Update is called once per frame
    void Update()
    {
        // Handle movement
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);
        body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);
        
        // Jump logic
        if (Input.GetKey(KeyCode.Space))
        {
            body.velocity = new Vector2(body.velocity.x, speed);
        }

        // Flip player when facing left/right
        if (horizontalInput > 0.01f)
            transform.localScale = Vector3.one;
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);

        // Jump if grounded
        if (Input.GetKey(KeyCode.Space) && grounded)
            Jump();

        // Set animation parameters
        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("grounded", grounded);
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, speed);
        anim.SetTrigger("jump");
        grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            grounded = true;
    }

    // Trigger when player collects a stone
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Stone")) // Check if the object is a stone
        {
            CollectStone();
            Destroy(other.gameObject); // Destroy the stone after collection
        }
    }

    // Method to handle stone collection
    public void CollectStone()
    {
        stonesCollected++; // Increase the stone count
        UpdateStoneCountUI(); // Update the UI
    }

    // Update the UI text with the current stone count
    private void UpdateStoneCountUI()
    {
        if (stonesText != null)
        {
            stonesText.text = "Stones Collected: " + stonesCollected;
        }
    }
}

