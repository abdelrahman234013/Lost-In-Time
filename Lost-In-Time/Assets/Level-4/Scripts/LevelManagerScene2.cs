using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManagerScene2 : MonoBehaviour
{
     public GameObject CurrentCheckPoint;
     public GameObject EnemyLevel4Scene2;
     public GameObject EnemyCheckPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RespawnPlayer(){
        FindObjectOfType<CharacterMovements>().transform.position = CurrentCheckPoint.transform.position;
        EnemyLevel4Scene2.transform.position = EnemyCheckPoint.transform.position;
    }

    public void GameOver() {
       
    }
}
