using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerIceS1 : MonoBehaviour
{
    public float moveSpeed;
    public float jumpHeight;
    public KeyCode Spacebar;
    public KeyCode L;
    public KeyCode R;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool grounded;
    private Animator anim;
    public KeyCode Return;
    public Transform firepoint;
    public GameObject bullet;
    public AudioClip jump1;
    //public AudioClip jump2;
    //public AudioClip bulletsound;
    public KeyCode P;  // Key to pull the box
    public LayerMask boxLayer;  // Layer of the box
    private GameObject detectedBox;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(Spacebar) && grounded)
        {
            Jump();
        }

        if (Input.GetKey(L))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);

            if (GetComponent<SpriteRenderer>() != null)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
        }

        if (Input.GetKey(R))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);

            if (GetComponent<SpriteRenderer>() != null)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
        }

        DetectBox();

        anim.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));
        anim.SetBool("Grounded", grounded);

        if (Input.GetKeyDown(Return))
        {
            Shoot();
        }
    }

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

    }

    public void Shoot()
    {
        Instantiate(bullet, firepoint.position, firepoint.rotation);
        //AudioManagerScript.instance.RandomizeSfx(bulletsound);
    }

    void Jump()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
       // AudioManagerScript.instance.RandomizeSfx(jump1); //, jump2);
    }

    void DetectBox()  // Detects and interacts with a box in front of the player
    {
        // Raycast to detect box in front of the player (based on the player's facing direction)
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * (GetComponent<SpriteRenderer>().flipX ? -1 : 1), 1f, boxLayer);

        if (hit.collider != null)
        {
            detectedBox = hit.collider.gameObject;

            if (Input.GetKey(P))  // Pull the box when pressing 'P'
            {
                // Pull the box towards the player
               // detectedBox.GetComponent<BoxBoulderScript>().MoveBox(transform.position);
            }
            else
            {
                // Push the box based on player velocity (moving in the direction the player is facing)
                Vector2 pushVelocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, 0);
//                detectedBox.GetComponent<BoxBoulderScript>().MoveBox(pushVelocity);
            }
        }
        else
        {
            detectedBox = null;  // No box detected in front of the player
        }
    }

}
