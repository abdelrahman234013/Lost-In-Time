using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    public Transform bottomPosition;  // The position for option 1 (bottom)
    public Transform middlePosition; // The position for option 3 (middle)
    public Transform topPosition;    // The position for option 2 (top)

    public float moveSpeed = 2f; // Speed of the platform's movement

    private Vector3 targetPosition;  // The position the platform is moving to

    private void Start()
    {
        // Set initial position to middle
        if (middlePosition != null)
        {
            targetPosition = middlePosition.position;
            transform.position = middlePosition.position;
        }
    }

    private void Update()
    {
        // Smoothly move the platform to the target position
        if (transform.position != targetPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
    }

    // Method to set the target position based on lever option
    public void MovePlatformTo(string option)
    {
        switch (option)
        {
            case "Option1":
                if (bottomPosition != null) targetPosition = bottomPosition.position;
                break;
            case "Option2":
                if (topPosition != null) targetPosition = topPosition.position;
                break;
            case "Option3":
                if (middlePosition != null) targetPosition = middlePosition.position;
                break;
        }
    }
}
