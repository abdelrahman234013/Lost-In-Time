using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Spear : MonoBehaviour
{
 public float Speed=4.5f;
 // Start is called before the first frame update
 void Start()
 {
 Debug.Log(Speed);
 }
 // Update is called once per frame
 void Update()
 {
 transform.position+= transform.right * Time.deltaTime * Speed;
 }
 public void OnCollisionEnter2D (Collision2D collision){
Destroy(gameObject);
}
void OnTriggerEnter2D(Collider2D other){
    if (other.tag=="Enemy"){
        Destroy(other.gameObject);
        Destroy(this.gameObject);
    }
}
}
