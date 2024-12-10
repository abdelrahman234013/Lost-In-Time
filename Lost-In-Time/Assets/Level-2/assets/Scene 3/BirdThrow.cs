using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdThrow : MonoBehaviour
{
    public GameObject stonePrefab;    // Stone prefab to instantiate
    public float throwForce = 10f;    // Force to apply when throwing the stone
    public Transform throwPoint;      // Point from where the stone will be thrown (in front of the bird)
    
    private Rigidbody rb;             // Bird's Rigidbody to check movement
    private int stonesThrown = 0;     // Keep track of how many stones the bird has thrown
    public int maxStones = 3;         // Max number of stones the bird can throw before needing to "reload"
    public float throwInterval = 2f;  // Interval between throws (in seconds)
    
    public float reloadTime = 3f;     // Time before the bird can throw again (reload time)
    
    private bool isMoving = false;    // To track whether the bird is moving or not

    void Start()
    {
        rb = GetComponent<Rigidbody>();  // Get the bird's Rigidbody component
        StartCoroutine(ThrowStonePeriodically());  // Start throwing stones periodically
    }

    void Update()
    {
        // Check if the bird is moving (velocity magnitude greater than 0)
        isMoving = rb.velocity.magnitude > 0.1f;

        // Only allow throwing if the bird is moving and hasn't reached the max stone count
        if (isMoving && stonesThrown < maxStones)
        {
            // Throwing logic is handled by the coroutine, so no need to add anything here for input
        }
    }

    // Coroutine for throwing stones periodically while the bird is moving
    IEnumerator ThrowStonePeriodically()
    {
        while (stonesThrown < maxStones)  // Continue throwing until max stones are thrown
        {
            // Wait for the specified throw interval
            yield return new WaitForSeconds(throwInterval);

            // Check if the bird is moving before throwing
            if (isMoving)
            {
                ThrowStone();  // Call the method to throw a stone
            }
        }

        // Once all stones are thrown, wait for reload time and reset the throw count
        StartCoroutine(ReloadStones());
    }

    // Method to throw a stone
    public void ThrowStone()  // Make this method public
    {
        // Instantiate the stone at the throw point position with no rotation
        GameObject stone = Instantiate(stonePrefab, throwPoint.position, Quaternion.identity);

        // Get the Rigidbody component of the stone to apply force
        Rigidbody rbStone = stone.GetComponent<Rigidbody>();

        // Apply a forward force to the stone (toward where the bird is facing)
        Vector3 throwDirection = transform.forward;  // Bird's forward direction
        rbStone.AddForce(throwDirection * throwForce, ForceMode.Impulse);

        // Optionally, add a small upward force to give the stone an arc-like motion
        rbStone.AddForce(Vector3.up * 2f, ForceMode.Impulse);

        // Increment the number of stones thrown
        stonesThrown++;

        // Print the current number of stones thrown (for debugging purposes)
        Debug.Log("Stones thrown: " + stonesThrown);

        // Optionally, destroy the stone after 5 seconds to clean up the scene
        Destroy(stone, 5f);  // Destroy the stone after 5 seconds
    }

    // Coroutine to handle reload time
    private IEnumerator ReloadStones()
    {
        // Wait for the specified reload time
        Debug.Log("Reloading stones...");
        yield return new WaitForSeconds(reloadTime);

        // Reset the stone count
        stonesThrown = 0;
        Debug.Log("Reload complete. Stones are available again.");

        // Restart the periodic throwing
        StartCoroutine(ThrowStonePeriodically());
    }
}
