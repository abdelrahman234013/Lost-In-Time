using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageLevel2 : MonoBehaviour
{
    public static ManageLevel2 instance;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Corrected capitalization of gameObject
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // You can use Update for handling any other game logic if needed
    }

    public void NextLevel()
    {
        // Corrected the typo and used LoadSceneAsync correctly
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadSceneAsync(nextSceneIndex); // Corrected method name
    }
}

