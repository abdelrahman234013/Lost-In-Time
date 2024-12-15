using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class WalkingEnemyS1 : EnemyControllerS1
{
 public Transform pointA; // Starting point of movement range
 public Transform pointB; // Ending point of movement range
 private bool movingRight = true; // Movement direction
 //public GameObject snowballPrefab; // Prefab of the snowball
 //public Transform snowballSpawnPoint; // Spawn point for the snowball
 //public float throwCooldown = 2f; // Cooldown time between snowball throws
 //private float throwTimer = 0f; // Timer to track snowball throws
 private GameObject player; // Reference to the player
 void Start()
 {
 player = GameObject.FindGameObjectWithTag("Player");
}
 void FixedUpdate()
 {
 // Movement logic
 if (movingRight)
 {
 transform.position += new Vector3(maxSpeed * Time.deltaTime, 0, 0);
 // Ensure the enemy is facing right
 if (!isFacingRight)
 {
 Flip();
 }
 }
 else
 {
 transform.position -= new Vector3(maxSpeed * Time.deltaTime, 0, 0);
 // Ensure the enemy is facing left
 if (isFacingRight)
 {
 Flip();
 }
 }
 // Flip at boundaries
 if (movingRight && transform.position.x >= pointB.position.x)
 {
 movingRight = false;
 }
 else if (!movingRight && transform.position.x <= pointA.position.x)
 {
 movingRight = true;
}
 // Handle snowball throw cooldown
/*throwTimer += Time.deltaTime;
 if (throwTimer >= throwCooldown)
 {
 ThrowSnowball();
 throwTimer = 0f;
 }
  }*/
 void OnTriggerEnter2D(Collider2D collider)
 {
 if (collider.tag == "Wall" || collider.tag == "Spike" || collider.tag == "Enemy")
 {
 Flip();
 movingRight = !movingRight; // Change direction upon collision
 }
 if (collider.tag == "Player")
 {
 FindObjectOfType<PlayerStatsIceS1>().TakeDamage(damage);
 Flip();
 movingRight = !movingRight; // Change direction upon collision
 }
 }
 /* void ThrowSnowball()
 {
 if (player == null) return; // Ensure the player exists
 // Instantiate the snowball
 GameObject snowball = Instantiate(snowballPrefab, snowballSpawnPoint.position, Quaternion.identity);
 // Determine direction towards the player
 Rigidbody2D rb = snowball.GetComponent<Rigidbody2D>();
 float direction = player.transform.position.x > transform.position.x ? 1f : -1f;
 // Set snowball velocity
 float snowballSpeed = 5f; // Adjust this value as needed
 rb.velocity = new Vector2(snowballSpeed * direction, 0f);
 // Flip snowball to face the right direction
 if (direction < 0f && snowball.transform.localScale.x > 0f)
 {
 snowball.transform.localScale = new Vector3(-snowball.transform.localScale.x, snowball.transform.localScale.y, snowball.transform.localScale.z);
 }*/
 }
}



