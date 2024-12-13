using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int health = 6;
    public int lives = 3;
    public float flickerTime = 0f;
    public float flickerDuration = 0.1f;
    private SpriteRenderer spriteRenderer;
    public bool isImmune = false;
    public float immuneTime = 0f;
    public float immuneDuration = 1.5f;
    public bool hasCard = false;
    public bool hasCapsule = false;
    private int coinsCollected = 0;
    private Animator animator;
    // public TextMeshProUGUI ScoreUI;
    // public Image healthBar;


    void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();

        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(this.isImmune == true){
            SpirteFlicker();
            immuneTime = immuneTime + Time.deltaTime;
            if(immuneTime >= this.immuneDuration){
                this.isImmune = false;
                this.spriteRenderer.enabled = true;
            }
        }

        
    }

    void SpirteFlicker()
{
    if (animator != null && !this.isImmune)
    {
        if (this.flickerTime < this.flickerDuration)
        {
            this.flickerTime += Time.deltaTime;
        }
        else
        {
            spriteRenderer.enabled = !spriteRenderer.enabled;
            this.flickerTime = 0f;
        }
    }
}

   public void TakeDamage(int damage)
{
    if (!this.isImmune && health > 0)
    {
        this.health -= damage;
        if (this.health < 0) this.health = 0;

        if (this.health == 0 && this.lives > 0)
        {
            
            FindObjectOfType<LevelManager>().RespawnPlayer();
            this.health = 6;
            this.lives--;
        }
        else if (this.lives == 0 && this.health == 0)
        {
            TriggerDeathAnimation();
        }

        Debug.Log("Player Health: " + this.health.ToString());
    }

    PlayHitReaction(); 
}
    void TriggerDeathAnimation()
{
    if (animator != null)
    {
        animator.SetTrigger("Death"); 
    }
    StartCoroutine(HandleDeath());
}

IEnumerator HandleDeath()
{
    
    yield return new WaitForSeconds(2f);  

    
    FindObjectOfType<LevelManager>().GameOver();


    Destroy(this.gameObject);
}


    void PlayHitReaction()
{
    this.isImmune = true;
    this.immuneTime = 0f;

    if (animator != null)
    {
        animator.ResetTrigger("Hurt");
        animator.SetTrigger("Hurt");
    }
}

    public void CollectCoin(int coinValue)
    {
        this.coinsCollected = this.coinsCollected + coinValue;
    }
}

