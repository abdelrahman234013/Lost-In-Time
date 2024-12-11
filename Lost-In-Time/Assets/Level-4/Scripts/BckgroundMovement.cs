using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BckgroundMovement : MonoBehaviour
{

    private float startPosX, lengthX;
    private float startPosY, lengthY;
    public GameObject cam;
    public float parallaxEffect;

    // Start is called before the first frame update
    void Start()
    {
        startPosX = transform.position.x;
        startPosY = transform.position.y;
        lengthX = GetComponent<SpriteRenderer>().bounds.size.x;
        lengthY = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distanceX = cam.transform.position.x * parallaxEffect;
        float distanceY = cam.transform.position.y * parallaxEffect;
        float movementX = cam.transform.position.x * (1 - parallaxEffect);
        float movementY = cam.transform.position.y * (1 - parallaxEffect);

        transform.position = new Vector3(startPosX + distanceX, transform.position.y, transform.position.z);
    
    if (movementX > startPosX + lengthX )
        {
            startPosX += lengthX;

        } else if(movementX < startPosX - lengthX)
        {
            startPosX -= lengthX;
        } 

         if (movementY > startPosY + lengthY )
     {
            startPosY += lengthY;
   
        } else if(movementY < startPosY - lengthY)
       {
           startPosY -= lengthY;
    } 
    
    }
}
