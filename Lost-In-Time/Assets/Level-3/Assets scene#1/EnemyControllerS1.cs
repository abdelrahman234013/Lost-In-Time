using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControllerS1 : MonoBehaviour
{
    public bool isFacingRight = false;
    public float maxSpeed = 3f;
    public int damage = 6;
    public AudioClip hit1;
    public AudioClip hit2;
    //public GameObject snowballPrefab; // Prefab of the snowball
   // public Transform snowballSpawnPoint; // Spawn point for the snowball
    private GameObject player;
    private float timer;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
       /* float distance = Vector2.Distance(transform.position, player.transform.position);
        if (distance < 4)
        {
            timer += Time.deltaTime;
            if (timer > 2)
            {
                timer = 0;
                Shoot();
            }
        }*/
    }

    public void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.localScale = new Vector3(-(transform.localScale.x), transform.localScale.y, transform.localScale.z);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            AudioManagerScript.instance.RandomizeSfx(hit1, hit2);
            FindObjectOfType<PlayerStatsIceS1>().TakeDamage(damage);
        }
    }

   /* void Shoot()
    {
        GameObject snowball = Instantiate(snowballPrefab, snowballSpawnPoint.position, Quaternion.identity);
    }*/
}
