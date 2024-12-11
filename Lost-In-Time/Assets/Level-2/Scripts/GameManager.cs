using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
public static GameManager instance;

    void Awake()
    {
        // Check if an instance already exists
        if (instance == null)
        {
            // Set the instance to this GameManager
            instance = this;

            // Make sure the GameManager persists across scenes
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Destroy duplicate GameManagers
            Destroy(gameObject);
        }
    }

    public void LoadScene(int sceneBuildIndex)
    {
        // Load the scene by its build index
        SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
    }
}
