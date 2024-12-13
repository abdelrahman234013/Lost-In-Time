using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointScript : MonoBehaviour
{
    public AudioClip PassedSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag=="Player")
        {
            FindObjectOfType<ManagerScript>().CurrentCheckpoint = this.gameObject;
            AudioManagerScript.instance.RandomizeSfx(PassedSound);
        }
    }
}
