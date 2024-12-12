using UnityEngine;

public class Meteor : MonoBehaviour
{
    public int damage = 1;

   
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.CompareTag("Player"))
        {
           
            PlayerStats playerStats = collision.GetComponent<PlayerStats>();
            if (playerStats != null)
            {
                playerStats.TakeDamage(damage);
            }

            Destroy(gameObject);
        }
    }
}
