using UnityEngine;

public class Card : MonoBehaviour
{
    public GameObject portal;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            
            FindObjectOfType<PlayerStats>().hasCard = true;

            
            if (portal != null)
            {
                Renderer portalRenderer = portal.GetComponent<Renderer>();
                if (portalRenderer != null)
                {
                    
                    portal.SetActive(true);
                }
                else
                {
                    Debug.LogWarning("Portal does not have a Renderer component!");
                }
            }
            else
            {
                Debug.LogError("Portal reference is missing! Assign the portal GameObject in the Inspector.");
            }

            
            Destroy(this.gameObject);
        }
    }
}
