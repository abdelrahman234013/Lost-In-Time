using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2BackgroundMovement : MonoBehaviour
{

    private float startPosX, lengthX;
    public GameObject cam;
    public float parallaxEffect;

    void Start()
    {
        startPosX = transform.position.x;
        lengthX = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void FixedUpdate()
    {
        float distanceX = cam.transform.position.x * parallaxEffect;
        float movementX = cam.transform.position.x * (1 - parallaxEffect);

        transform.position = new Vector3(startPosX + distanceX, transform.position.y, transform.position.z);
    
    if (movementX > startPosX + lengthX )
        {
            startPosX += lengthX;

        } else if(movementX < startPosX - lengthX)
        {
            startPosX -= lengthX;
        } 
    }
}
