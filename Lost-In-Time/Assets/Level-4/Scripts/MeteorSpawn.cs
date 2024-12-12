using UnityEngine;

public class MeteorSpawn : MonoBehaviour
{
    public GameObject meteorPrefab;
    public float spawnInterval = 20f;
    public float meteorSpeed = 5f;
    public Transform enemy;
    public Transform player;
    public float spawnHeight = 5f;

    private float spawnTimer = 0f; 

    void Update()
    {
    
        spawnTimer += Time.deltaTime;

       
        if (spawnTimer >= spawnInterval)
        {
            SpawnMeteor();
            spawnTimer = 0f;
        }
    }

    void SpawnMeteor()
    {
        
        Vector3 spawnPosition = new Vector3(enemy.position.x, enemy.position.y + spawnHeight, enemy.position.z);

        
        GameObject meteor = Instantiate(meteorPrefab, spawnPosition, Quaternion.identity);

        
        Rigidbody2D rb = meteor.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            
            Vector2 directionToPlayer = (player.position - meteor.transform.position).normalized;

            
            rb.velocity = directionToPlayer * meteorSpeed;
        }

        
    }
}
