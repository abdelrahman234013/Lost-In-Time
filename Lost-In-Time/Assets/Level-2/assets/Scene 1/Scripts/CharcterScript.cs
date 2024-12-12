using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharcterScript : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D body;
    private Animator anim;
    private bool grounded;

    public int stonesCollected = 0;
    public Text stonesText;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        UpdateStoneCountUI();
    }

    void Update()
    {
        if (anim.GetBool("dead")) return;  // If the character is dead, stop updating

        // Handle movement
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        if (Input.GetKey(KeyCode.Space) && grounded)
        {
            Jump();
        }

        if (horizontalInput > 0.01f)
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);

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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Stone"))
        {
            CollectStone();
            Destroy(other.gameObject);
        }
    }

    public void CollectStone()
    {
        stonesCollected++;
        UpdateStoneCountUI();
    }

    private void UpdateStoneCountUI()
    {
        if (stonesText != null)
        {
            stonesText.text = "Stones Collected: " + stonesCollected;
        }
    }
}
