using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueScript : MonoBehaviour
{
   public TextMeshProUGUI textDisplay; //a special variable that holds the TextMeshPro - Text for manipulation
   private string [] dialogueSentences; //an array that stores all the sentences to be displayed
   private int index = 0; //a variable that signifies which sentence is being printed or to be printed
   public float typingSpeed; //a variable to control the speed of the typewriter effect
   public GameObject continueButton; //a variable that holds the continue button
   public GameObject dialogueBox; //a variable that holds the panel (dialogue box)
   public Rigidbody2D player; //a variable that holds the player's/character's Rigidbody2D component

   void Start()
    {
     /*the purpose of this script is to be called whenever a certain event happens,
     therefore, both the dialogue box and the continue button should be disabled*/
     dialogueBox.SetActive(false);
     continueButton.SetActive(false);

     /*if dialgoue should occur at the start of the scene or level, then the below sequence should done
     firstly, construct your array with the intended size, then set the sentences you want, and then finally start the Coroutine*/
     //dialogueSentences = new string[3];
     //dialogueSentences[0] = "This is a welcome sentence.";
     //dialogueSentences[1] = "Narration narration narration, narration narration. Blah blah blah blah blah.";
     //dialogueSentences[2] = "This is a farewall sentence.";
     //StartCoroutine(Type());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator TypeDialogue()
    {
      dialogueBox.SetActive(true); //enables the dialogue box
      player. constraints = RigidbodyConstraints2D. FreezePositionX | RigidbodyConstraints2D. FreezePositionY; //freezing the player in place

      foreach (char letter in dialogueSentences[index].ToCharArray()) //converting the sentence to an array of char to loop through each char
       {
         textDisplay.text += letter; //adding each char to the displayed text

         yield return new WaitForSeconds(typingSpeed); /*this special type of return is used with the IEnumerator and StartCoroutine() function
         to pause the execution of this function (TypeDialogue) for the specified (typingSpeed) amount of seconds, then after this amount
         of seconds has passed this function (TypeDialogue) continues its exectution*/

         if (textDisplay.text == dialogueSentences[index]) //checks if the whole sentence has been printed to enable the continue button
           {
              continueButton.SetActive(true);
           }
       }
    } 

    public void SetSentences(string[] sentences) //sets the sentences array to the passed on array
    {
      this.dialogueSentences = sentences;
    }

    public void NextSentence() //this function, if able, is used to increment the index which in turn moves the dialogue to the next sentence
    {
      continueButton.SetActive(false); //disables the continue button to avoid bugs
      if (index < dialogueSentences. Length -1) //if there are more sentences then
       {
         index++; //move to the next sentence
         textDisplay.text = ""; //clear the displayed text
         StartCoroutine(TypeDialogue()); //start the coroutine again to display the new sentence
       }
      else
       {         
          //this section gets executed when all sentences have been displayed
          textDisplay.text = ""; //clear the displayed text
          continueButton.SetActive(false); //disable the continue button
          dialogueBox.SetActive(false); //disable the dialogue box
          this.dialogueSentences = null; //clear the sentences array
          index = 0; //reset the index
          player.constraints = RigidbodyConstraints2D.None; //unfreeze the player
          player.constraints = RigidbodyConstraints2D.FreezeRotation; //freeze the player's rotation as it was before
       }
    }
}


