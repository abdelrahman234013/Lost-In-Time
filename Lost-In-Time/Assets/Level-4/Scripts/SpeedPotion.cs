using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPotion : MonoBehaviour
{
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
            FindObjectOfType<CharacterMovements>().moveSpeed += 5;
            Destroy(this.gameObject);
        }
    }
}
