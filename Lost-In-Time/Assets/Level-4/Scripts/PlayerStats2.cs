using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats2 : MonoBehaviour
{
    
    public int health = 3;
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
     public Animator animator;
    // public TextMeshProUGUI ScoreUI;
    // public Image healthBar;


    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
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
                FindObjectOfType<LevelManagerScene2>().RespawnPlayer();
                this.health = 3;
                this.lives--;
            } else if(this.lives == 0 && this.health == 0){
                FindObjectOfType<LevelManagerScene2>().GameOver();
                Destroy(this.gameObject);

            }

            Debug.Log("Player Health: " + this.health.ToString());
            // Debug.Log("Player Lives: " + this.lives.ToString());
        }
        PlayHitReaction();
        // healthBar.fillAmount = this.health/3f;
        
    }

    void PlayHitReaction(){
        // animator.SetBool("isHurt", isImmune);
        this.isImmune = true;
        this.immuneTime = 0f;
    }

    public void CollectCoin(int coinValue)
    {
        this.coinsCollected = this.coinsCollected + coinValue;
    }
}
