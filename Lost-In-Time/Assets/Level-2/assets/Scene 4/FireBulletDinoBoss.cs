using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBulletDinoBoss : MonoBehaviour
{
    public float speed = 10f; 
    public float damage = 20f;
    private Vector3 direction;

    public float time = 5f;

    void Start()
    {
        // Destroy the bullet after timeToLive seconds
        Destroy(gameObject, time);
    }

    void Update()
    {
         transform.position += direction * speed * Time.deltaTime;
    }


    public void SetDirection(Vector3 newDirection)
    {
        direction = newDirection.normalized; // Normalize for consistent speed
    }

    
    void OnTriggerEnter2D(Collider2D other){

        if (other.CompareTag("Player"))
        {
            other.GetComponent<HealthScript>().TakeDamage(damage);
            Destroy(gameObject);
        }
        else if (other.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}
