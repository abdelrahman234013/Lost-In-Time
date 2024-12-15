using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObsctacle : MonoBehaviour
{
    public float speed;
    Vector3 targetPos;
    public int damage;

    public GameObject ways; 
    public Transform[] wayPoints;

    int pointIndex;
    int pointCount;

    int direction = 1;
 

    // Awake is called when the script instance is being loaded
    private void Awake()
    {
        // Initialize the wayPoints array based on the number of child objects in the 'ways' GameObject
        wayPoints = new Transform[ways.transform.childCount];
        for (int i = 0; i < ways.transform.childCount; i++)
        {
            wayPoints[i] = ways.transform.GetChild(i).transform;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        pointCount = wayPoints.Length;
        pointIndex = 0;  // Start at the first point
        targetPos = wayPoints[pointIndex].position;
    }

    // Update is called once per frame
    void Update()
    {
        // Move the obstacle towards the target position
        var step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPos, step);

        // Check if the obstacle has reached the target position
        if (transform.position == targetPos)
        {
            NextPoint();  // Move to the next point
        }
    }

    // Moves to the next waypoint
    void NextPoint()
    {
        // Reverse direction when reaching the first or last point
        if (pointIndex == pointCount - 1)
        {
            direction = -1;  // Move back
        }
        if (pointIndex == 0)
        {
            direction = 1;   // Move forward
        }

        // Update the point index based on the direction
        pointIndex += direction;
        targetPos = wayPoints[pointIndex].position;  // Set the next target position
    }
     void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag=="Player")  // Better to use CompareTag for efficiency
        {
            // Call the method that handles the player's damage
  
            FindObjectOfType<PlayerStats>().TakeDamage(damage);
              FindObjectOfType<LevelManager>().RespawnPlayer();
        }
    }
    
}
