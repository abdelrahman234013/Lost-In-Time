using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
   public GameObject restartPanel; // Drag your Restart Panel here from the UI

    void Start()
    {
        restartPanel.SetActive(false);  // Ensure the panel is hidden at the start
    }

    // Call this method when the character dies
    public void GameOver()
    {
        // Show the restart panel
        restartPanel.SetActive(true);
    }

    // Call this method to restart the game
    public void RestartGame()
    {
        // Reload the current scene (this will restart the game)
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void TestGameOver()
{
    GameOver(); // This will manually trigger the GameOver() function
}
}
