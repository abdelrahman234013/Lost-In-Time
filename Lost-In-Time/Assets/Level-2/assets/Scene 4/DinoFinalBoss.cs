using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoFinalBoss : MonoBehaviour
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

    void Start()
    {
        transform.position = new Vector3(transform.position.x, -1f, transform.position.z);
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
            yield return new WaitForSeconds(3);

            transform.position = new Vector3(transform.position.x, -0.8f, transform.position.z);
            animator.SetTrigger("AttackTrigger");

            FireBullet();

            yield return new WaitForSeconds(3);

            animator.SetTrigger("ReverseAttackTrigger");
            transform.position = new Vector3(transform.position.x, -1f, transform.position.z);
            yield return new WaitForSeconds(3);

            isIdle = false;
            isImmune = false;
            animator.SetBool("IsWalking", true);

            isAtPointA = false;
            isAtPointB = false;

            yield return MoveToTarget();

            transform.position = new Vector3(transform.position.x, OrigianlY, transform.position.z);
            animator.SetBool("IsWalking", false);
            isIdle = true;

            transform.position = new Vector3(transform.position.x, -1f, transform.position.z);
            yield return new WaitForSeconds(3);
        }
    }

void FireBullet()
{
    if (isFacingRight == Vector3.right){
        Vector3 fireDirection = Vector3.left;
    }
    else {
        Vector3 fireDirection = Vector3.right;
    }

    // Instantiate the fire bullet at the appropriate position
    GameObject bullet = Instantiate(
        fireBulletPrefab,
        transform.position + fireDirection * 1.5f,
        Quaternion.identity
    );

    // Flip the bullet's sprite if the boss is facing left
    if (!isFacingRight)
    {
        bullet.transform.localScale = new Vector3(-1, 1, 1);
    }

    // Assign the movement direction to the bullet's script
    FireBulletDinoBoss bulletScript = bullet.GetComponent<FireBulletDinoBoss>();
    if (bulletScript != null)
    {
        bulletScript.SetDirection(fireDirection);
    }
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
        animator.SetTrigger("DeadTrigger");
        StartCoroutine(DisappearAfterDeath());
    }
    else
    {
        animator.SetTrigger("HurtTrigger");
    }
}

    IEnumerator DisappearAfterDeath()
    {   
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
}