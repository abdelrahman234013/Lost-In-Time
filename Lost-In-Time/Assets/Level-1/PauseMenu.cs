using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject PausePanel;

    public void Pause()
    {
        PausePanel.SetActive(true);
        Time.timeScale=0;

    }

    public void Home()
    {
        SceneManager.LoadScene("Main Menu");
          Time.timeScale=1;
    }

    public void Resume()
    {
        PausePanel.SetActive(false);
          Time.timeScale=1;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    void Start()
    {
        // No need for any code here
    }

    void Update()
    {
        // No need for any code here
    }
}