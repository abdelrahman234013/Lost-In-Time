using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovements : MonoBehaviour
{
   public float moveSpeed;
    public float jumpHeight;
    public bool isFacingRight;
    public KeyCode Spacebar;
    public KeyCode L;
    public KeyCode R;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    public Animator animator;
    private bool grounded;
    public KeyCode E;
    public Transform firepoint;
    public GameObject bullet;
    public AudioSource shootSound;   
    



    // Start is called before the first frame update
    void Start()
    {
      isFacingRight= true;   
      animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       
animator.SetFloat("Speed",Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));
        if(Input.GetKeyDown(Spacebar) && grounded){
            Jump();
        }
            animator.SetBool("isJumping", grounded);

        if(Input.GetKey(L)){
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
             
            if(isFacingRight){
                Flip();
                isFacingRight = false;
            }
        }

        if(Input.GetKey(R)){
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            
            if(!isFacingRight){
                Flip();
                isFacingRight = true;
            }
        }


         if(Input.GetKeyDown(E)){
             Shoot();
         }
        
    }

    public void Shoot(){
         Instantiate(bullet,firepoint.position, firepoint.rotation);
          if (shootSound != null)
        {
            shootSound.Play();
        }
    }
    void Jump(){
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
    }

    void FixedUpdate(){
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }

    void Flip(){
        transform.localScale = new Vector3(-(transform.localScale.x), transform.localScale.y, transform.localScale.z);
    }

    public void OnLanding() {
        // animator.SetBool("isJumping", false);
    }
}
