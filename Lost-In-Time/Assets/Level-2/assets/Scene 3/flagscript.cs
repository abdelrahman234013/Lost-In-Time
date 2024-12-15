using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flagscript : MonoBehaviour
{
    // Start is called before the first frame update
    public static Vector3 lastCheckpointPosition;
    public float healthBonus = 1f;  // Amount of health to add when reaching this checkpoint

  private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            lastCheckpointPosition = transform.position;
            
            Debug.Log("Checkpoint reached!");
        }
    }
}

