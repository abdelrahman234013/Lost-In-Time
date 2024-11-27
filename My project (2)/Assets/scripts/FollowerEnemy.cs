using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerEnemy : EnemyController
{
    public float speedtowardplayer;  // Speed at which the enemy moves towards the player

    private PlayerMovements player; // Reference to the PlayerController script

    // Start is called before the first frame update
    void Start()
    {

        player = FindObjectOfType<PlayerMovements>(); //Find the PlayerController object in the scene

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, MaxSpeed * Time.deltaTime);

    }

}