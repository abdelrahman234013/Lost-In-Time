using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMove : MonoBehaviour
{
    public int sceneBuildIndex;

    // Level move zone entered, if collider is the player
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player")) 
        {
            // When player enters trigger, call GameManager to load the new scene
            Debug.Log("Switching Scene to " + sceneBuildIndex);
            GameManager.instance.LoadScene(sceneBuildIndex);
        }
    }
}
