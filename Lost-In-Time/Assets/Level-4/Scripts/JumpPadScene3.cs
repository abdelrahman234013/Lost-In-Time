using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPadScene3 : MonoBehaviour
{
    public float jumpForce = 10f;

    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        
        if (collider.gameObject.CompareTag("Player"))
        {
            collider.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}
