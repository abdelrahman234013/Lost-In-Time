using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public bool IsFacingRight = false;
    public float MaxSpeed = 3f;
    public int Damage = 6;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Flip() {
        IsFacingRight = !IsFacingRight;
        transform.localScale = new Vector3(-(transform.localScale.x), transform.localScale.y, transform.localScale.z);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            FindObjectOfType<PlayerStats>().TakeDamage(Damage);
        }
    }
}
