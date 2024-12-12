using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traps : MonoBehaviour
{

    public int Damage = 6;

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
            FindObjectOfType<PlayerStats>().TakeDamage(Damage);
        }
    }
}
