using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickUPS1 : MonoBehaviour
{
    // public int keyValue;
    public AudioClip keySound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.tag=="Player"){
            FindObjectOfType<PlayerStatsIceS1>().CollectedKey();
           
            //AudioManager.instance.PlaySingle(coinSound);
           // AudioManager.instance.RandomizeSfx(shardSound);
            Destroy(this.gameObject);
            Debug.Log("key Collected!");
            // Debug.Log("Key Value: " + keyValue);

        }
    }
}
