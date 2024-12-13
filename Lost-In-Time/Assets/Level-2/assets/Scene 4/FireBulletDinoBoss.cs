using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBulletDinoBoss : MonoBehaviour
{
    public float speed = 10f; 
    public float damage = 20f;

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    
    void OnTriggerEnter2D(Collider2D other){

        if (other.CompareTag("Player"))
        {
            //other.GetComponent<HealthScript>().TakeDamage(damage);
            Destroy(gameObject);
        }
        else if (other.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}
