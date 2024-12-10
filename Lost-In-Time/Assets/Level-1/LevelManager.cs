using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject CurrentCheckpoint;
    public Transform enemy;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RespawnPlayer()
    {
        Instantiate(enemy, transform.position, transform.rotation);
    }

}
