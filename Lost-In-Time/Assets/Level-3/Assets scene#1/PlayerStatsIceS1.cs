using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsIceS1 : MonoBehaviour
{
   public int health = 3;
    public int lives = 3;
    public int maxHealth = 3; // Maximum health per hear
    private int maxLives = 3; // Number of hearts the player can have

    private float flickerTime = 0f;
    public float flickerDuration = 0.1f;
    private SpriteRenderer spriteRenderer;
    public bool isImmune = false;
    private float immunityTime = 0f;
    public float immunityDuration = 1.5f;
    public int shardsCollected = 0;
    public int keyCollected = 0;
    public AudioClip deathSound;
    private Animator animator;

    //public TextMeshProUGUI ScoreUI;  // Score UI to show collected coins
   // public Image healthbar; // Health bar Image reference
   // public Image[] heartImages; // Array of heart images for lives (drag all heart images in the inspector)

    //public TextMeshProUGUI ScoreUi;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(this.isImmune == true)
        {
            SpriteFlicker();
            immunityTime = immunityTime + Time.deltaTime;
            if(immunityTime >= immunityDuration)
            {
                this.isImmune = false;
                this.spriteRenderer.enabled = true;
            }
        }
    }

    void SpriteFlicker()
    {
        if(this.flickerTime<this.flickerDuration)
        {
            this.flickerTime = this.flickerTime + Time.deltaTime;
        }
        else if (this.flickerTime >= this.flickerDuration)
        {
            spriteRenderer.enabled = !(spriteRenderer.enabled);
            this.flickerTime = 0;
        }
    }
    public void TakeDamage(int damage)
    {
        if (!this.isImmune && health > 0)
        {
            this.health -= damage;
            if (this.health < 0) this.health = 0;

            // Update health bar based on current health
            //healthbar.fillAmount = (float)health / maxHealth;  // Divide by maxHealth to dynamically adjust health bar

            // Check if health in current heart is 0
            if (this.health == 0 && this.lives > 0)
            {
                // Decrease the life (heart) and reset health for the next heart
                this.lives--;
                health = maxHealth;  // Reset health for the next heart

                // Update hearts display
                //UpdateHearts();

                // Respawn if there are remaining lives
                if (this.lives > 0)
                {
                    FindObjectOfType<LevelManager>().RespawnPlayer();
                }
            }
            else if (this.lives == 0 && this.health == 0)
            {
                //TriggerDeathAnimation();
            }

            Debug.Log("Player Health: " + this.health.ToString());
        }

        PlayHitReaction();
    }

    /* public void TakeDamage (int damage)
     {
         if (this.isImmune == false)
         {
             this.health = this.health - damage;
             if (this.health < 0)
             {
                 this.health = 0;
             }

             if (this.lives > 0 && this.health == 0)
             {
                 FindObjectOfType<ManagerScriptS1>().RespawnPlayer();
                 this.health = 3;
                 this.lives--;
             }
             else if (this.lives == 0 && this.health == 0)
             {
                 Debug.Log("Gameover");
                 //AudioManagerScript.instance.PlaySingle(deathSound);
               //  AudioManagerScript.instance.musicSource.Stop();
                 Destroy(this.gameObject);
             }

             Debug.Log("Player Health:" + this.health.ToString());
             Debug.Log("Player Lives:" + this.lives.ToString());
         }

         PlayHitReaction();
     }
    */
    void PlayHitReaction()
    {
        this.isImmune = true;
        this.immunityTime = 0f;
    }

    public void CollectedShard(int shardValue)
    {
        this.shardsCollected = this.shardsCollected + shardValue;
    }

     public void CollectedKey(int keyValue)
    {
        this.keyCollected = this.keyCollected + keyValue;
    }
}

