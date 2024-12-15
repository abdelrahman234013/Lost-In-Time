using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class potion : MonoBehaviour
{
    public int potionValue;
    public AudioClip potionSound;
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
            FindObjectOfType<PlayerStatsIce>().Collectedpotion(potionValue);
           
            //AudioManager.instance.PlaySingle(coinSound);
           // AudioManager.instance.RandomizeSfx(shardSound);
            Destroy(this.gameObject);
            Debug.Log("snow potion Collected!");
            Debug.Log("potion Value: " + potionValue);

        }
    }
}
