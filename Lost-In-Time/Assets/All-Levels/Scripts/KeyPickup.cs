using UnityEngine;
using UnityEngine.Video;

public class KeyPickup : MonoBehaviour
{
    public GameObject key;
    public bool isPickedUp = false;

    public VideoPlayer videoPlayer;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isPickedUp)
        {
            
            isPickedUp = true;

            Debug.Log("Key picked up!");

            
            if (videoPlayer != null)
            {
                videoPlayer.Play();
                Debug.Log("Playing video...");
            }
            else
            {
                Debug.LogWarning("Video Player not assigned!");
            }

            
            Destroy(gameObject);
        }
    }
}