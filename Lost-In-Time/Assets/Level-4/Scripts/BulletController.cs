using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed;
    public int damage = 2;

    public float timeremaining;
    // Start is called before the first frame update
    void Start()
    {
        PlayerStats player;

        player=FindObjectOfType<PlayerStats>();

        if(player.transform.localScale.x<0){
            speed=-speed;
            transform.localScale=new Vector3(-(transform.localScale.x),transform.localScale.y,transform.localScale.z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity=new Vector2(speed,GetComponent<Rigidbody2D>().velocity.y);
        if(timeremaining>0){
            timeremaining-=Time.deltaTime;
        }
        else if(timeremaining<=0){
            Destroy(this.gameObject);
        }
        
    }
    void OnTriggerEnter2D(Collider2D other){
         if (other.tag == "Boss")
        {
           
            Scene3Enemy bossHealth = other.GetComponent<Scene3Enemy>();
            if (bossHealth != null)
            {
                bossHealth.TakeDamage(damage);
            }

            Destroy(this.gameObject); 
        }
    }
}
