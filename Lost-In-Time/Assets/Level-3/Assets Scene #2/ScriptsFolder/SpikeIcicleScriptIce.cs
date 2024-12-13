using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeIcicleScriptIce : MonoBehaviour
{
    public int damage = 2;

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
        if (other.tag == "Player")
        {
            //AudioManagerScript.instance.RandomizeSfx(hit1, hit2);
            FindObjectOfType<PlayerStatsIce>().TakeDamage(damage);
        }
    }
}
