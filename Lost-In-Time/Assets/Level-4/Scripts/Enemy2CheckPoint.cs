using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2CheckPoint : MonoBehaviour
{
     void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D (Collider2D other){
        if(other.tag == "Player"){
            FindObjectOfType<LevelManagerScene2>().EnemyCheckPoint = this.gameObject;
        }
    }
}
