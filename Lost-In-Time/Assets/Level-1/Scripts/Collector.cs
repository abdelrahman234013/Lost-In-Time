using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    public int coinValue;
   // public AudioClip coinSound;

    void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {

            //AudioScript.instance.RandomizeSfx(coinSound); ///run the sound

            FindObjectOfType<PlayerStats>().CollectCoin(coinValue);
            Destroy(this.gameObject);

        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
