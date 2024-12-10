using UnityEngine;

public class BirdController : MonoBehaviour
{
    public float speed = 5f;   // Speed of the bird's movement
    public float disappearPoint = -10f;  // The x-position where the bird will disappear
    public float heightVariation = 1f;  // How much the bird fluctuates in height (y-axis)
    public GameObject stonePrefab;  // Reference to the stone prefab
    public Transform stoneSpawnPoint; // Where the stone will be spawned from the bird

    private Vector2 startPosition;
    private Rigidbody2D rb;
    private float throwCooldown = 1f;  // Time between throwing stones
    private float nextThrowTime = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  // Get the Rigidbody2D component
        startPosition = transform.position;  // Store the bird's starting position
    }

    void Update()
    {
        // Move the bird from right to left
        float newX = transform.position.x - speed * Time.deltaTime;
        float newY = startPosition.y + Mathf.Sin(Time.time) * heightVariation; // Optional: adds a flapping effect

        // Apply the movement to the bird
        transform.position = new Vector2(newX, newY);

        // Throw stone after a certain cooldown
        if (Time.time > nextThrowTime && stonePrefab != null)
        {
            ThrowStone();
            nextThrowTime = Time.time + throwCooldown;  // Set the next throw time
        }

        // Check if the bird has passed the disappear point
        if (transform.position.x < disappearPoint)
        {
            Destroy(gameObject);  // Destroy the bird when it moves past the disappear point
        }
    }

    void ThrowStone()
    {
        // Instantiate the stone at the spawn point and apply an initial velocity
        GameObject stone = Instantiate(stonePrefab, stoneSpawnPoint.position, Quaternion.identity);

        // Apply a force to the stone to make it move
        Rigidbody2D stoneRb = stone.GetComponent<Rigidbody2D>();
        if (stoneRb != null)
        {
            // Give the stone an initial horizontal velocity to the left
            stoneRb.velocity = new Vector2(-10f, 0f);  // Adjust the speed as needed
        }
    }
}
