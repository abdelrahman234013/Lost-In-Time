using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    public int damage;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    // Corrected the spelling of OnTriggerEnter2D
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag=="Player")  // Better to use CompareTag for efficiency
        {
            // Call the method that handles the player's damage
  
            FindObjectOfType<PlayerStats>().TakeDamage(damage);
        }
    }
}
