using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    public int damage;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void onTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {

           // FindObjectOfType<LevelManager>().RespawnPlayer();
            FindObjectOfType<PlayerStats>().TakeDamage(damage);
            Debug.Log("moooot");
        }
    }

}

