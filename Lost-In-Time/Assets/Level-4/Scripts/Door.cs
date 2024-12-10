using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("hasCard",  FindObjectOfType<PlayerStats>().hasCard);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player" && FindObjectOfType<PlayerStats>().hasCard) {
            Destroy(other.gameObject);
        }
    }
}