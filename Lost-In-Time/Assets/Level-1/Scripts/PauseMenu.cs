using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject PausePanel;
    [SerializeField] AudioSource backgroundMusic;

    public void Pause()
    {
        PausePanel.SetActive(true);
        Time.timeScale=0;
        backgroundMusic.Pause();

    }

    public void Home()
    {
        SceneManager.LoadScene(0);
          Time.timeScale=1;
    }

    public void Resume()
    {
        PausePanel.SetActive(false);
          Time.timeScale=1;
        backgroundMusic.Play();
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