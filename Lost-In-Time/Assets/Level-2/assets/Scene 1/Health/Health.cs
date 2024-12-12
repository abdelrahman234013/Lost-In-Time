using System.Collections;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;
    private CharcterScript characterScript;
    public Transform respawnPoint;  // Reference to the respawn point

    void Start()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        characterScript = GetComponent<CharcterScript>();
    }

    public void TakeDamage(float _damage)
    {
        Debug.Log("Damage taken: " + _damage);
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            anim.SetTrigger("hurt");
        }
        else
        {
            if (!dead)
            {
                anim.SetTrigger("die");
                GetComponent<CharcterScript>().enabled = false;
                dead = true;
                StartCoroutine(Respawn());  // Start respawn process
            }
        }
    }

    private IEnumerator Respawn()
    {
        // Wait for a short period of time to show the death animation
        yield return new WaitForSeconds(2f);

        // Move the character to the respawn point
        transform.position = respawnPoint.position;

        // Reset the health and enable the character's script again
        currentHealth = startingHealth;
        characterScript.enabled = true;

        // Reset death status and any other required variables
        dead = false;
        anim.SetTrigger("respawn");  // Optionally, trigger a respawn animation if you have one
    }

    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) TakeDamage(1);
    }
}
