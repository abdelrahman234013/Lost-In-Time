using UnityEngine;
using System.Collections;


public class Scene3Enemy : MonoBehaviour
{
    public Transform player;
    public bool isFlipped = false;
    public int maxHealth = 100;
    private int currentHealth;
    public int attackDamage = 20;
    public float attackRange = 8f;
    public HealthBarScene3 healthBar;
    public AudioSource detectionAudio;
    public float detectionRange = 100f;
    private bool hasDetectedPlayer = false;
    private bool hasStartedRunning = false;
    private float runDelay = 5f;
    private float runTimer = 0f;
    public Animator animator; 
    private Rigidbody2D rb;
    public float speed = 15f;
    public GameObject FinalKey;
    public float keyDropForce = 5f;
    public int healthRegenerationAmount = 10;
    public float healthRegenerationInterval = 10f;

    void Start()
    {
        currentHealth = maxHealth;
        if (healthBar != null)
        {
            healthBar.SetMaxHealth(maxHealth);
        }

        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        StartCoroutine(HealthRegenerationCoroutine());

        
    }

    IEnumerator HealthRegenerationCoroutine()
{
    while (currentHealth > 0)
    {
        yield return new WaitForSeconds(healthRegenerationInterval);
        RegenerateHealth();
    }
}

   
    public void LookAtPlayer()
{
    if (player == null) return;

    Vector3 flipped = transform.localScale;
    flipped.z *= -1f;

    if (transform.position.x > player.position.x && isFlipped)
    {
        transform.localScale = flipped;
        transform.Rotate(0f, 180f, 0f);
        isFlipped = false;
    }
    else if (transform.position.x < player.position.x && !isFlipped)
    {
        transform.localScale = flipped;
        transform.Rotate(0f, 180f, 0f);
        isFlipped = true;
    }
}

    
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }

        if (healthBar != null)
        {
            healthBar.SetHealth(currentHealth);
        }
    }

    void Die()
    {
        animator.SetTrigger("Die");

        rb.velocity = Vector2.zero;
        rb.isKinematic = true;
        GetComponent<Collider2D>().enabled = false;

        DropKey();

        
        Destroy(gameObject, 2f);
    }

    void DropKey()
{
    if (FinalKey != null)
    {
        
        GameObject key = Instantiate(FinalKey, transform.position + Vector3.down * 0.5f, Quaternion.identity);
    }
}



    
    public bool IsPlayerInRange()
    {
        return Vector3.Distance(transform.position, player.position) <= detectionRange;
    }

    public void Attack()
{
    
    
    Collider2D hit = Physics2D.OverlapCircle(transform.position, attackRange, LayerMask.GetMask("Player"));
    if (hit != null)
    {
        
        hit.GetComponent<PlayerStats>().TakeDamage(attackDamage);
    }
}

 void RegenerateHealth()
{
    if (currentHealth < maxHealth)
    {
        currentHealth += healthRegenerationAmount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        if (healthBar != null)
        {
            healthBar.SetHealth(currentHealth);
        }
    }
}




    void Update()
{
    if (player == null || player.GetComponent<PlayerStats>().health <= 0)
    {
        animator.SetBool("IsRunning", false);
        return; 
    }

    if (!hasDetectedPlayer && IsPlayerInRange())
    {
        if (detectionAudio != null)
        {
            detectionAudio.Play();
        }
        hasDetectedPlayer = true;
    }

    if (hasDetectedPlayer && !hasStartedRunning)
    {
        runTimer += Time.deltaTime;
        if (runTimer >= runDelay)
        {
            hasStartedRunning = true;
            animator.SetBool("IsRunning", true);
        }
    }

    if (hasStartedRunning)
    {
        Vector2 targetPosition = new Vector2(player.position.x, rb.position.y);

        if (Vector2.Distance(transform.position, player.position) > attackRange)
        {
            Vector2 newPos = Vector2.MoveTowards(rb.position, targetPosition, speed * Time.deltaTime);
            rb.MovePosition(newPos);
        }

        LookAtPlayer();

       
        if (Vector2.Distance(transform.position, player.position) <= attackRange)
        {
            Attack();
            animator.SetTrigger("Attack");
        }
    }
}
}