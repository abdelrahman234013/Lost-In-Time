using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPC : MonoBehaviour
{
     public Dialogue dialogueManager; // a variable that stores the Dialogue script that is attached to the Dialogue Manager gameobject

    // Use this for Initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") // if the player is the one that triggers the collider, then
        {
            string[] dialogue = {
                "TARS: Congratulation Jack for reaching this far!",
                "Jack: Who Are You!",
                "TARS: I'm a security robot programmed to protect research facilities from intruders in HYDRA.",
                "TARS: But After what oblivion did, I developed advanced combat skills and tried to take oblivion down but I couldn't",
                "TARS: so I developed a weapon that can kill Oblivion and ready to assist any one that is worthy to take him down.",
                "TARS: And by reaching this level, you are a worthy worrior Jack!",
                "Jack: who is Oblivion?",
                "TARS: Oblivion Is the Destroyer of this world, anyone that tries to bring our technology back he kills him immediately",
                "TARS: Now get the Weapon and Go get 'em, Tiger!"
            }; // specify the dialogue between the player and the character (Flower)

            dialogueManager.SetSentences(dialogue); // set the sentences array in the Dialogue script to above array
            dialogueManager.StartCoroutine(dialogueManager.TypeDialogue()); // start the coroutine of TypeDialogue(), which in turn starts the dialogue
        }
    }

}
