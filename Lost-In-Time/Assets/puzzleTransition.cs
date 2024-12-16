using UnityEngine;
using UnityEngine.SceneManagement;

public class puzzleTransition : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadSceneAsync(13);
        }
    }
}
