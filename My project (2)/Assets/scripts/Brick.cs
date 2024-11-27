using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{

    private SpriteRenderer sr;
    public Sprite explodedBlock;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        // Check if the collision hit the bottom of the block
        if (other.gameObject.tag == "Player" && other.GetContact(0).point.y < transform.position.y)
        {
                // Change the Block sprite
                sr.sprite = explodedBlock;

                // Wait a fraction of a second and then destroy the BrickBlock
                Object.Destroy(gameObject, 0.2f);
        }
    }
}
