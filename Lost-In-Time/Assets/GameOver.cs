using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour 
{
    // Method to quit the game
    public void QuitGame() {
        Application.Quit();
    }

    // Method to retry the current game by reloading the active scene
    public void RetryGame() {
        // Get the current active scene and reload it
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadSceneAsync(currentScene.name);
    }
}

