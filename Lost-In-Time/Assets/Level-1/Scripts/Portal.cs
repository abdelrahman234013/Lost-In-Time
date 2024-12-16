using UnityEngine;
using UnityEngine.SceneManagement;  // Make sure to include this to use SceneController

public class Portal : MonoBehaviour
{
    [SerializeField] bool goNextLevel;  // Corrected typo here
    [SerializeField] string levelName;  // Corrected typo here (variable name should follow camelCase)

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (goNextLevel)
        {
            if (collision.CompareTag("Player"))
            {
                SceneController.instance.NextLevel();  // Ensure you have a method named 'NextLevel' in SceneController
            }
            else
            {
                SceneController.instance.LoadScene(levelName);  // Corrected variable name here
            }
        }
    }
}
