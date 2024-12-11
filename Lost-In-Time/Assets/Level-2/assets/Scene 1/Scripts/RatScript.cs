using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatScript : MonoBehaviour
{
    public GameObject PointA;
    public GameObject PointB;
    private Rigidbody2D rb;
    private Animator anim;
    private Transform currentPoint;
    public float speed;
    [SerializeField] private float damage;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentPoint = PointB.transform;  // Start by moving towards PointB
        anim.SetBool("isRunning", true);
    }

    private void flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;  // Flip the scale horizontally
        transform.localScale = localScale;
    }

    // Update is called once per frame
    void Update()
    {
        // Move towards the current target point
        Vector2 targetPosition = currentPoint.position;
        Vector2 moveDirection = (targetPosition - (Vector2)transform.position).normalized;
        
        // Move the rat towards the target
        rb.velocity = moveDirection * speed;

        // Check if the rat has reached the target point (A or B)
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f)
        {
            // Flip the rat when it reaches the current point
            flip();

            // Switch the target point
            if (currentPoint == PointB.transform)
            {
                currentPoint = PointA.transform;  // Move to PointA
            }
            else
            {
                currentPoint = PointB.transform;  // Move to PointB
            }
        }
    }

    // Optional: For debugging, visualize the points and movement path
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(PointA.transform.position, 0.5f);
        Gizmos.DrawWireSphere(PointB.transform.position, 0.5f);
        Gizmos.DrawLine(PointA.transform.position, PointB.transform.position);
    }

    // Detect collision with the player and apply damage
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Health>().TakeDamage(damage);
        }
    }
}
