using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShardPickUpS1 : MonoBehaviour
{
    public int shardValue;
    public AudioClip shardSound;
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
            FindObjectOfType<PlayerStatsIceS1>().CollectedShard(shardValue);
           
            //AudioManager.instance.PlaySingle(coinSound);
           // AudioManager.instance.RandomizeSfx(shardSound);
            Destroy(this.gameObject);
            Debug.Log("shard Collected!");
            Debug.Log("Shard Value: " + shardValue);

        }
    }
}
