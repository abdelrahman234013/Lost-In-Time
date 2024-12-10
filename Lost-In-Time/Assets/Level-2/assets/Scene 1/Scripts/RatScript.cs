using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatScript : MonoBehaviour
{
   
    public GameObject PointA;
    public GameObject PointB;
    private Rigidbody2D rb;
    private Animator anim;
    private Transform currentPoint;
    public float speed;
  [SerializeField] private float damage;
  
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentPoint = PointB.transform;
        anim.SetBool("isRunning",true);
    }


        private void flip(){
            Vector3 localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
        }

    // Update is called once per frame
    void Update()
    {
        Vector2 point = currentPoint.position - transform.position;
        if(currentPoint == PointB.transform){
            rb.velocity = new Vector2(speed,0);
        }
        else{
            rb.velocity = new Vector2(-speed,0);
        }

        if (Vector2.Distance(transform.position,currentPoint.position)<0.5f && currentPoint == PointB.transform){
            flip();
            currentPoint = PointA.transform;
        }
        if (Vector2.Distance(transform.position,currentPoint.position)<0.5f && currentPoint == PointA.transform){
            flip();
            currentPoint = PointB.transform;
        }

    }
    private void OnDrawGizmos(){
        Gizmos.DrawWireSphere(PointA.transform.position,0.5f);
        Gizmos.DrawWireSphere(PointB.transform.position,0.5f);
        Gizmos.DrawLine(PointA.transform.position,PointB.transform.position);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Health>().TakeDamage(damage);
        }
    }





}
