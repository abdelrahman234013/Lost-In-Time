using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capsule : MonoBehaviour
{
    public AudioClip audio;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            FindObjectOfType<PlayerStats>().hasCapsule = true;
            Destroy(this.gameObject);
              AudioManager2.instance.PlaySingle(audio);
        }
    }
}
