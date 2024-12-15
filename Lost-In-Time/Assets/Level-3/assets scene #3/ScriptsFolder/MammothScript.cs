using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MammothScript : MonoBehaviour
{
    public Animator animator;
    public Transform pointA;
    public Transform pointB;
    public float moveSpeed = 5f;
    private Transform currentTarget;

    public float health = 100f;
    private bool isDead = false;
    public float OrigianlY;

    public float pushForceX = 20f; 
    public float pushForceY = 30f; 
    private bool isFacingRight = true;
    private bool isAtPointA = true; 
    private bool isAtPointB = false; 
    private bool isIdle = true; 
    private bool isImmune = false; 
    public float DamageTail = 10f; 
    private bool Started = false;

    public Transform WallLeft;
    public Transform WallRight;

    public GameObject fireBulletPrefab;
    public GameObject[] spikes;
    public GameObject JumpPad1;
    public GameObject JumpPad2;
    public GameObject RewardKey;

    void Start()
    {
        transform.position = new Vector3(transform.position.x, -1f, transform.position.z);
        foreach (GameObject spike in spikes){ spike.SetActive(false); }
        JumpPad1.SetActive(false); JumpPad2.SetActive(false);
        RewardKey.SetActive(false);
    }

    public void StartBossFight()
    {
        if (!Started)
        {
            Started = true;
            StartCoroutine(BossBehavior()); // Start the boss behavior when the fight begins
        }

        OrigianlY = transform.position.y;
        currentTarget = pointA;

        StartCoroutine(DisableWallTriggersAfterDelay());
    }

    IEnumerator DisableWallTriggersAfterDelay(){

    yield return new WaitForSeconds(1);

    WallRight.GetComponent<Collider2D>().isTrigger = false;
    WallLeft.GetComponent<Collider2D>().isTrigger = false;

    }

    IEnumerator BossBehavior()
    {
        while (!isDead)
        {

            isIdle = true;
            transform.position = new Vector3(transform.position.x, -1f, transform.position.z);
            animator.SetBool("IsWalking", false);
            if (isDead) break;
            yield return new WaitForSeconds(3); // idle
            if (isDead) break;
            animator.SetTrigger("AttackTrigger");
            transform.position = new Vector3(transform.position.x, -0.8f, transform.position.z);
            foreach (GameObject spike in spikes){ spike.SetActive(true); }
            JumpPad1.SetActive(false); JumpPad2.SetActive(false);
            yield return new WaitForSeconds(1f); // wait before firing
            if (isDead) break;
            yield return FireMultipleBullets(4, 1.5f);
            if (isDead) break;
            animator.SetTrigger("ReverseAttackTrigger");
            transform.position = new Vector3(transform.position.x, -1f, transform.position.z);
            
            yield return new WaitForSeconds(4f); //wait after fire
            if (isDead) break;
            foreach (GameObject spike in spikes){ spike.SetActive(false); }
            JumpPad1.SetActive(true); JumpPad2.SetActive(true);
            if (isDead) break;
            isImmune = false;
            animator.SetBool("IsWalking", true);

            isAtPointA = false;
            isAtPointB = false;

            yield return MoveToTarget();

            transform.position = new Vector3(transform.position.x, OrigianlY, transform.position.z);
            animator.SetBool("IsWalking", false);
            isIdle = true;

            transform.position = new Vector3(transform.position.x, -1f, transform.position.z);
        }
    }
    
    IEnumerator FireMultipleBullets(int count, float interval)
    {
    for (int i = 0; i < count; i++)
    {
        FireBullet();
        yield return new WaitForSeconds(interval);
    }
    }

void FireBullet()
{
    Vector3 fireDirection = isFacingRight ? Vector3.left : Vector3.right;

    // Slightly lower the bullet by reducing the y coordinate
    Vector3 bulletPosition = transform.position + fireDirection * 1.5f;
    bulletPosition.y = -3f;  // Lower the bullet by 0.2 units (adjust this value as needed)
    // Instantiate the fire bullet at the adjusted position
    
    if (isFacingRight){
        bulletPosition.x -= 4f;  // Decrement x by 10 if facing right
    }
    else{
        bulletPosition.x += 4f;  // Increment x by 10 if facing left
    }

    GameObject bullet = Instantiate(fireBulletPrefab, bulletPosition, Quaternion.identity);
    // Flip the bullet's sprite if the boss is facing left
    if (!isFacingRight)
    {
        bullet.transform.rotation = Quaternion.Euler(0, 180, 0);
    }

    // Assign the movement direction to the bullet's script
    bullet.GetComponent<FireBulletDinoBoss>().SetDirection(fireDirection);
}

    IEnumerator MoveToTarget()
    {
        float startY = transform.position.y;
        float targetX = currentTarget.position.x;

        while (Mathf.Abs(transform.position.x - targetX) > 0.1f)
        {
            float step = moveSpeed * Time.deltaTime;
            transform.position = new Vector3(Mathf.MoveTowards(transform.position.x, targetX, step), startY, transform.position.z);

            yield return null;
        }

        if (currentTarget == pointA)
        {
            isAtPointA = true;
        }
        else if (currentTarget == pointB)
        {
            isAtPointB = true;
        }

        FlipDirection();
        currentTarget = currentTarget == pointA ? pointB : pointA;
    }

    void FlipDirection()
    {
        Vector3 scale = transform.localScale;
        scale.x = -scale.x;
        transform.localScale = scale;

        isFacingRight = scale.x > 0;
    }

    public void TakeDamage(float damage)
{
    if (!isIdle || isImmune || isDead) return;

    health -= damage; isImmune = true;

    if (health <= 0)
    {
        isDead = true;
        animator.SetTrigger("Dead");
        StartCoroutine(DisappearAfterDeath());
    }
    else
    {
        animator.SetTrigger("Hurt");
    }
}

    IEnumerator DisappearAfterDeath()
    {   
        RewardKey.SetActive(true);
        foreach (GameObject spike in spikes){ spike.SetActive(false); }
        JumpPad1.SetActive(true); JumpPad2.SetActive(true);
        WallRight.GetComponent<Collider2D>().isTrigger = true;
        yield return new WaitForSeconds(0.8f);
        animator.SetBool("IsDead", true);
        transform.position = new Vector3(transform.position.x, -1.5f, transform.position.z);

        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            if (isAtPointA || isAtPointB) 
            {
                Rigidbody2D playerRb = collision.GetComponent<Rigidbody2D>();

                    Vector2 pushDirection = !isFacingRight ? Vector2.right : Vector2.left;
                    pushDirection *= pushForceX;
                    pushDirection.y = pushForceY;

                    playerRb.velocity = Vector2.zero; 
                    playerRb.AddForce(pushDirection, ForceMode2D.Impulse);

                    TakeDamage(DamageTail);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
{
    if (collision.collider.CompareTag("Player"))
    {
        Debug.Log("Player hit by the boss!");
    }
}

}