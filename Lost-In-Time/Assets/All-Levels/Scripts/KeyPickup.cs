using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    public GameObject key;
    public bool isPickedUp = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isPickedUp)
        {
            
            isPickedUp = true;
            
            Debug.Log("Key picked up!");

            
            Destroy(gameObject);
        }
    }
}
