using UnityEngine;

public class boxpull : MonoBehaviour
{
    public float distance = 1f;  // How far in front of the player the box will be detected
    public LayerMask boxMask;  // The layer mask for detecting the box
    public KeyCode interactKey = KeyCode.E;  // The key used to interact (default: E)

    private GameObject box;  // The box that will be pulled
    private FixedJoint2D fixedJoint;  // The FixedJoint2D component

    void Start()
    {
        // Get the FixedJoint2D component attached to the Player
        fixedJoint = GetComponent<FixedJoint2D>();  
        fixedJoint.enabled = false;  // Ensure the joint is disabled initially
    }

    void Update()
    {
        // Raycast to detect box in front of the player
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distance, boxMask);

        if (hit.collider != null && hit.collider.CompareTag("Box")) // Ensure we hit the box
        {
            box = hit.collider.gameObject;  // Assign the box

            if (Input.GetKeyDown(interactKey))  // When E is pressed
            {
                // Enable the FixedJoint2D and attach the box to the player
                fixedJoint.enabled = true;
                fixedJoint.connectedBody = box.GetComponent<Rigidbody2D>();  // Connect box's Rigidbody2D
            }
            else if (Input.GetKeyUp(interactKey))  // When E is released
            {
                // Disable the FixedJoint2D to detach the box from the player
                fixedJoint.enabled = false;
            }
        }
    }

    // Debug the raycast visually (to help with troubleshooting)
    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.right * distance);
    }
}
