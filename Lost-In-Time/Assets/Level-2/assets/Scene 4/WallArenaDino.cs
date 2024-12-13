using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallArenaDino : MonoBehaviour{
    public DinoFinalBoss boss;
    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.CompareTag("Player")){
            boss.StartBossFight();
        }
    }
}
