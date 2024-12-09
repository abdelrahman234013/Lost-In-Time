using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;


    void Start()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
    }

  public void TakeDamage(float _damage)
    {
         Debug.Log("Damage taken: " + _damage); 
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            anim.SetTrigger("hurt");
            //iframes
        }
        else
        {
            if (!dead)
            {
                anim.SetTrigger("die");
                GetComponent<CharcterScript>().enabled = false;
                dead = true;
            }
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        TakeDamage(1);
    }

  

    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }
}
