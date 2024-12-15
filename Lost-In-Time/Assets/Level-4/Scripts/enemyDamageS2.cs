using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDamageS2 : MonoBehaviour
{
    public int Damage =1 ;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            FindObjectOfType<PlayerStats2>().TakeDamage(Damage);
        }
    }
}
