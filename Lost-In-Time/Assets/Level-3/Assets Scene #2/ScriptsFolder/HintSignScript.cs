using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintSignScript : MonoBehaviour
{
 public DialogueScript dialogueManager; //a variable that stores the Dialogue script that is attached to the Dialogue Manager gameobject

 // Use this for initialization
 void Start () 
 {
 }

 // Update is called once per frame
 void Update () 
    {

      void OnTriggerEnter2D(Collider2D other)
        {
         if (other.CompareTag("Player")) //if the player is the one that triggers the collider, then
            {
                string[] dialogue = { "Hint: Try opening the chests, using the 'O' button!"/*"Flower: Sonic, wait! Take a break and drink this before you proceed."
                                      "Sonic: What's goin' on?",
                                      "Flower: Eggman and his new robot and thrashing the town!",
                                      "Flower: Knuckles and the others are tryna take 'im down.",
                                      "Flower: Now take this honey - it'll restore your stamina!",
                                      "Sonic: Thanks! I'm on it!"*/
                                    }; //specify the dialogue between the player and the character(flower)
                //dialogueManager.SetSentences(dialogue); //set the sentences array in the Dialogue script to above array
                //dialogueManager.StartCoroutine(dialogueManager.TypeDialogue()); //start the coroutine of TypeDialogue(), which in turn starts the dia
            }
        }
    }
}
