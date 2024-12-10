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
    public int coinsCollected = 0;
    // public TextMeshProUGUI ScoreUI;
    // public Image healthBar;




    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
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

    void SpirteFlicker(){
        if(this.flickerTime < this.flickerDuration){
            this.flickerTime = this.flickerTime + Time.deltaTime;
        } else{
            spriteRenderer.enabled = !(spriteRenderer.enabled);
            this.flickerTime = 0;
        } 
    }

    public void TakeDamage(int damage){
        if(this.isImmune == false){
            this.health = this.health - damage;
            if(this.health < 0){
                this.health = 0;
            }
            if(this.lives > 0 && this.health == 0){
                FindObjectOfType<LevelManager>().RespawnPlayer();
                this.health = 6;
                this.lives--;
            } else if(this.lives == 0 && this.health == 0){
                FindObjectOfType<LevelManager>().GameOver();
                Destroy(this.gameObject);

            }
            else{
                // FindObjectOfType<LevelManager>().RespawnPlayer();
            }

            Debug.Log("Player Health: " + this.health.ToString());
            // Debug.Log("Player Lives: " + this.lives.ToString());
        }

        PlayHitReaction();

        this.health = health - damage;
        // healthBar.fillAmount = this.health/3f;
        
    }

    void PlayHitReaction(){
        this.isImmune = true;
        this.immuneTime = 0f;
    }

    public void CollectCoin(int coinValue)
    {
        this.coinsCollected = this.coinsCollected + coinValue;
    }
}

