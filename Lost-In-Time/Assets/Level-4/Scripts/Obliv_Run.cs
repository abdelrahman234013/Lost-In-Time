using UnityEngine;

public class Obliv_Run : StateMachineBehaviour
{
    public float speed = 2.5f;
    private Transform player;
    private Rigidbody2D rb;
    public float attackRange = 3f;
    private Scene3Enemy boss;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
        rb = animator.GetComponent<Rigidbody2D>();
        boss = animator.GetComponent<Scene3Enemy>();

        if (player == null)
        {
            return;
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
{
    boss.LookAtPlayer();
    
    
    float distanceToPlayer = Vector2.Distance(player.position, rb.position);
    
    
    if (distanceToPlayer > attackRange)
    {
        Vector2 target = new Vector2(player.position.x, rb.position.y);
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPos);
    }
    else
    {
        rb.velocity = Vector2.zero;
    }

    if (distanceToPlayer <= attackRange)
    {
        animator.SetTrigger("Attack");
    }
}

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
    }
}
