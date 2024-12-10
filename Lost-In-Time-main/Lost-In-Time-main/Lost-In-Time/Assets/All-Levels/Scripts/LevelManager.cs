using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
     public GameObject CurrentCheckPoint;

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
    }

    public void GameOver() {
        Debug.Log("Game Over");
    }
}
