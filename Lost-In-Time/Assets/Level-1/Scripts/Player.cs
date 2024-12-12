using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
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
    private bool Grounded;
    private Animator anim;

    public KeyCode Return; /// determine the keyboard button for shooting
    public Transform firepoint; ///determine the position of shooting in the player character 
    public GameObject bullet;     //fire   //I have to make a prefab


    void Start()
    {
        anim = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(Spacebar))
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

        if (Input.GetKeyDown(Return))
        {

            Instantiate(bullet, firepoint.position, firepoint.rotation);
        }

        anim.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));
        anim.SetFloat("Grounded", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.y));
    }

    void Jump()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
    }


    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }

    public class PlayerController : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public float flickerDuration = 0.1f;
    public Color flickerColor = Color.red;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Spike")
        {
            StartCoroutine(Flicker());
        }
    }

    private IEnumerator Flicker()
    {
        Color originalColor = spriteRenderer.color;
        float elapsedTime = 0f;

        while (elapsedTime < flickerDuration)
        {
            spriteRenderer.color = flickerColor;
            yield return new WaitForSeconds(flickerDuration / 2);
            spriteRenderer.color = originalColor;
            yield return new WaitForSeconds(flickerDuration / 2);
            elapsedTime += flickerDuration;
        }
    }
}

}
// Animator
//1- Set the transactions 
//2- Go to parameters 
//3- Go to add var bool
//4- Click on the arrows and set then one true and other false
//5- Click on uncheck the exit
